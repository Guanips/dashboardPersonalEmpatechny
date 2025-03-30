import express from "express"
import cors from "cors"
import sqlite3 from "sqlite3"

const app = express();
const PORT = process.env.PORT || 3000;

app.use(cors());
app.use(express.json());

sqlite3.verbose();

const DB_FILE = 'hospital.db';

const db = new sqlite3.Database(DB_FILE, sqlite3.OPEN_READWRITE | sqlite3.OPEN_CREATE, (err) => {
  if (err) {
    console.error('Error al conectar con SQLite:', err.message);
    return;
  }
  console.log('Conectado a la base de datos SQLite.');

});

//RUTAS HTTP

app.get('/get_reportes', (req, res) => {
    db.all("SELECT * FROM reportes_salas", [], (err, rows) => {
        res.send(rows)
    })

});
  
app.get('/get_preguntas', (req, res) => {
    res.send
    (
    [
        {
            id_pregunta: 1,
            contenido_pregunta: "¿Cómo te sientes hoy?",
        },
        {
            id_pregunta: 2,
            contenido_pregunta: "¿Qué tan cansado/a te sientes ahora?",
        },
        {
            id_pregunta: 3,
            contenido_pregunta: "¿Qué tan contento/a te sientes aquí?",
        },
        {
            id_pregunta: 4,
            contenido_pregunta: "¿Qué tan preocupado/a estás por lo que está pasando?",
        },
        {
            id_pregunta: 5,
            contenido_pregunta: "¿Cómo te sentís con las personas que te cuidan aquí?",
        }
    ]
    )
})

app.post('/post_login', (req, res) => {
    const credenciales = req.body;
    console.log(credenciales)

    db.get(`SELECT password FROM personal_salud WHERE usuario = ?`, [credenciales.username], (err, row) => {
        if (err) {
          console.error('Error checking for user:', err.message);
          return;
        }
      
        if (row) {
          if (row.password === credenciales.password) {
            console.log('Login successful!');
            res.send({
                status: "login exitoso",
                mensaje: "Bienvenido " + credenciales.username
            })
          } else {
            console.log('Incorrect password!');
            res.send({
                status: "login fallido",
                mensaje: "Contraseña o usuario incorrecto"
            })
          }
        } else {
          console.log('User does not exist!');
          res.send({
            status: "login fallido",
            mensaje: "Contraseña o usuario incorrecto"
        })
        }
      });
})

app.post('/post_reporte', (req, res) => {
    const { reporte } = req.body;
    console.log(reporte);
  });

app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
  });