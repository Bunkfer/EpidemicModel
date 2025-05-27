Primero debemos tener el servidor como Xlaunch de vcxsrv instalado

Construimos la imagen 
imagen original......docker build -t bunkfer/pyqt5:3.13.3-slim . 
imagen app episolver...docker build -t bunkfer/episolver . 

arrancamos el contenedor
imagen original......docker run -it --name episolver -e DISPLAY=host.docker.internal:0.0 bunkfer/pyqt5:3.13.3-slim
imagen app episolver...docker run -dit --name episolver -e DISPLAY=host.docker.internal:0.0 bunkfer/episolver

si queremos volver a arrancar la aplicacion
......docker start -ai episolver
......docker exec -it episolver bash ---- para entrar en el bash con el contenedor activo

para copiar los archivos creados en nuestra carpeta
......docker cp episolver:/app/modelos "C:\OnedriveOut"

para detener y borrar los contnedores 
..........docker stop episolver
..........docker container prune

Para arrancar solo la imagen en un contenedor totalmente vacio PRUEBAS
..........docker run -it -e DISPLAY=host.docker.internal:0.0 bunkfer/pyqt5:3.13.3-slim