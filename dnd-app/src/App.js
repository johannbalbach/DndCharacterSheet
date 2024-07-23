import './App.css';
import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from './store/store';
import MainContent from './components/MainContent';
import LoginForm from './components/profile/loginForm';
import ProfileForm from './components/profile/profileForm';
import Navbar from './components/Navbar';


function App() {
  return (
    <Provider store={store}>
    <Router>
    <div className="App">
      <Navbar />
      <main>
        <Routes>
          <Route path="/" element={<MainContent />} />
          <Route path="/login" element={<LoginForm />} />
          {/* <Route path="/register" element={<RegisterForm />} /> */}
          <Route path="/profile" element={<ProfileForm/>}/>
          {/* <Route path="/patients" element={<PatientsList/>}/>
          <Route path="/patient/:id" element={<PatientCard/>}/>
          <Route path="/inspection/create" element={<CreateInspection/>}/>
          <Route path="/inspection/:id" element={<InspectionDetails/>}/>
          <Route path="/reports" element={<ReportsPage/>}/>
          <Route path="/consultations" element={<ConsultationPage/>}/> */}
        </Routes>
      </main>
    </div>
    </Router>
  </Provider>
  );
}

export default App;
