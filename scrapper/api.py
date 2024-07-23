from gradio_client import Client


prompt = "human man barbarian with two-handed gratesword and full chainmail armor, DnD character, 8K, photo-realistic, high accuracy, detailed"

# client = Client("stabilityai/stable-diffusion-3-medium")
# result = client.predict(
# 		prompt=prompt,
# 		negative_prompt="",
# 		seed=0,
# 		randomize_seed=True,
# 		width=1024,
# 		height=1024,
# 		guidance_scale=5,
# 		num_inference_steps=28,
# 		api_name="/infer"
# )

# Returns tuple of 2 elements
# [0] filepath
# The output value that appears in the "Result" Image component.
# [1] float
# The output value that appears in the "Seed" Slider component.

client = Client("mukaist/Midjourney")
result = client.predict(
		prompt=prompt,
		negative_prompt="(deformed iris, deformed pupils, semi-realistic, cgi, 3d, render, sketch, cartoon, drawing, anime:1.4), text, close up, cropped, out of frame, worst quality, low quality, jpeg artifacts, ugly, duplicate, morbid, mutilated, extra fingers, mutated hands, poorly drawn hands, poorly drawn face, mutation, deformed, blurry, dehydrated, bad anatomy, bad proportions, extra limbs, cloned face, disfigured, gross proportions, malformed limbs, missing arms, missing legs, extra arms, extra legs, fused fingers, too many fingers, long neck",
		use_negative_prompt=True,
		style="Cinematic",
		seed=0,
		width=1024,
		height=1024,
		guidance_scale=6,
		randomize_seed=True,
		api_name="/run"
)

# possible style enum: ['2560 x 1440', 'Photo', 'Cinematic', 'Anime', '3D Model', '(No style)']
# Returns tuple of 2 elements
# [0] List[Dict(image: filepath, caption: str | None)]
# The output value that appears in the "Result" Gallery component.
# [1] float
# The output value that appears in the "Seed" Slider component.


print(result)