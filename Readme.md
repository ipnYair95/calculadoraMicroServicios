
# Ejemplo de Calculadora con NET y Microservicios

# Marín Alavez Edgar Yair

## Diagramas

En la carpeta diagramas, igual contiene la captura de exito de los Tests

## EndPoint

http://localhost:9090/makeOperation/{op}/{num1}/{num2}/

    * op: Operación a realizar donde acepta lo siguiente
        * Sumar -> sum
        * Restar -> subs
        * Multiplicar -> multi
        * Dividir -> div
    * num1,num2: Números enteros

## Test Realizados

    1) Operación valida
    2) No cero como denominador 
    3) Resultado esperado para cada operación

## ¿Qué se tomó en cuenta?

Para mi ejemplo solamente realicé 1 EndPoint que maneja las 4 operaciones.

1) Una vez recibidos los argumentos, pasamos los datos desde el facade hasta el servicio que para mi caso elegí esta capa debido a que no se usará una DB.

2) En la capa de servicio realizo las validaciones de operación y cero, donde este mismo será usado para las unit tests.

3) La solicitud la mapeo a un modelo de Calculadora donde su método primordial es el retornar la operación de acuerdo a lo solicitado.

4) Dicho resultado lo mapeo a un ResponseModel para retornar entre las capas y llegue al controller. Este ResponseModel le incluyo el resultado y un mensaje, especialmente para un error.

## Cosas por investigar

1) Retornar un código de respuesta: Ya que tengo entendido el ActionResult se encarga de eso pero me da ruido poner más de 1 return en el controller debido a que no hay lógica aqui y pense mandarlo desde otra capa.

2) Para mi caso la lógica fuerte la puse en los servicios, sin embargo, faltataría ver si se tiene que meter mejor en otra capa.

3) Configuración del appSettings para otros manejadores de DB ya que se intentó con MySql cambiando los parametros y rutas pero no fue satisfactorio.

4) Aprender C#. Para esta primer vista al lenguaje mucha de la información la logré comparar contra Java y Spring Boot, sin embargo para el caso de compilación hay muchas reglas definidas como espacios o maneras de documentar que te saltan warnings y errores.

