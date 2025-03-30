import React, { useEffect, useState } from 'react';
import axios from "axios"
import './App.css';
import TarjetaReportes from './components/TarjetaReportes/TarjetaReportes';

const App = () => {

  const [formData, setFormData] = useState({
    username: '',
    password: ''
  });

  const [loginStatus, setLoginStatus] = useState(true)
  const [reportes, setReportes] = useState([])

  useEffect(() => {
    console.log(reportes)
  },[reportes])

  const handleInputChange = (e) => {
    const { name, value } = e.target;
    setFormData((prevData) => ({
      ...prevData,
      [name]: value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    console.log('Submitted:', formData);
  };

  const checkLogin = () => {
    axios.post("http://localhost:3000/post_login", {
      username: formData.username,
      password: formData.password
    }).then((res) => {
      if(res.data.status == "login exitoso"){
        setLoginStatus(false)
        obtenerReportes()
      }
      alert(res.data.status + " - " + res.data.mensaje)
    }).catch((err)=> {
      console.log(err)
    })
  }

  const obtenerReportes = () => {
    axios.get("http://localhost:3000/get_reportes")
    .then((res) => {
      let resultado = res.data
      setReportes(resultado)
    })
  }

  const columns = reportes.length > 0 ? Object.keys(reportes[0]) : [];

  return (

    <>
      {loginStatus ? (
      <div className='outerLoginContainer'>
      <div className="containerLogin">
        <h1>Dashboard Personal Salud</h1>
        <h2>Login</h2>
        <form onSubmit={handleSubmit} className='containerForm'>
          <div>
            <label>Username:</label>
            <input
              type="text"
              name="username"
              value={formData.username}
              onChange={handleInputChange}
            />
          </div>
          <div>
            <label>Password:</label>
            <input
              type="password"
              name="password"
              value={formData.password}
              onChange={handleInputChange}
            />
          </div>
          <button type="submit" onClick={() => {checkLogin()}}>Login</button>
        </form>
      </div>
      </div>) : (
        <div className='mainContainer'>
          <p>Reportes sobre Encuestas de Bienestar</p>
      <table>
        <thead>
          <tr>
            {columns.map((column) => (
              <th key={column}>{column}</th>
            ))}
          </tr>
        </thead>
        <tbody>
          {reportes.map((report) => (
            <tr key={report.id_reporte}>
              {columns.map((column) => (
                <td key={column}>{report[column]}</td>
              ))}
            </tr>
          ))}
        </tbody>
      </table>
        </div>
      )}

    </>

  );
};

export default App;