import asyncio
import aiohttp
from selenium import webdriver
from selenium.webdriver.common.by import By
from selenium.webdriver.support.ui import WebDriverWait
from selenium.webdriver.support import expected_conditions as EC
from selenium.webdriver.chrome.service import Service as ChromeService
from selenium.webdriver.chrome.options import Options
from webdriver_manager.chrome import ChromeDriverManager
import time


class ImageScraper:
    def __init__(self):
        chrome_options = Options()
        #chrome_options.add_argument("--headless")
        chrome_options.add_argument("--no-sandbox")
        chrome_options.add_argument("--disable-dev-shm-usage")
        self.driver = webdriver.Chrome(service=ChromeService(ChromeDriverManager().install()), options=chrome_options)
        self.base_url = "https://huggingface.co/spaces/stabilityai/stable-diffusion-3-medium"

    def generate_image(self, prompt):
        self.driver.get(self.base_url)

        # Ожидание появления iframe и переключение на него, если он есть
        try:
            iframe = WebDriverWait(self.driver, 10).until(EC.presence_of_element_located((By.TAG_NAME, 'iframe')))
            self.driver.switch_to.frame(iframe)
        except:
            pass  # Если iframe нет, продолжаем без переключения

        # Явное ожидание загрузки input элемента
        input_box = WebDriverWait(self.driver, 20).until(
            EC.presence_of_element_located(
                (By.XPATH, '/html/body/gradio-app/div/div/div[1]/div/div/div/div[2]/div/label/input'))
        )

        # Вводим текстовый запрос в соответствующее поле
        input_box.send_keys(prompt)

        # Явное ожидание загрузки кнопки "Run"
        run_button = WebDriverWait(self.driver, 20).until(
            EC.element_to_be_clickable((By.CSS_SELECTOR, 'button#component-5'))
        )
        run_button.click()

        time.sleep(1)
        # Ждем завершения генерации
        while True:
            try:
                progress_element = self.driver.find_element(By.CSS_SELECTOR, 'div.progress-text')
                time.sleep(1)  # Ждем одну секунду
            except:
                break

        # Получаем URL сгенерированного изображения
        image_element = self.driver.find_element(By.CSS_SELECTOR, 'div.image-container img')
        image_url = image_element.get_attribute('src')

        return image_url

    async def download_image(self, session, url, save_path):
        async with session.get(url) as response:
            if response.status == 200:
                with open(save_path, 'wb') as f:
                    f.write(await response.read())

    async def download_generated_image(self, prompt, save_path):
        image_url = self.generate_image(prompt)
        async with aiohttp.ClientSession() as session:
            await self.download_image(session, image_url, save_path)

    def close(self):
        self.driver.quit()


# Пример использования
async def main():
    scraper = ImageScraper()
    prompt = "DND Character human man two-handed gratesword, detailed, 8k"
    save_path = "generated_image.webp"
    await scraper.download_generated_image(prompt, save_path)
    scraper.close()


if __name__ == "__main__":
    asyncio.run(main())