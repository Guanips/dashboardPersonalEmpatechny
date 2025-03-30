const TarjetaReportes = (props) => {

    return (
        <>
            <div className="contenedorTarjetaReporte">
                <p>{"Reporte Sala " + props.id_sala}</p>
                <p>Puntaje de Preguntas</p>
                <ol>
                    {props.preguntas.map(pregunta => <li>{pregunta.contenido_pregunta + " = " + {}}</li>)}
                </ol>
            </div>
        </>
    )
}

export default TarjetaReportes