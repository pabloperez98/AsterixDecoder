Bienvenidos al manual de uso de la aplicación AsterixDecoder, desarrollado por un estudiante de la EETAC (Universidad Politécnica de Cataluña). En este pequeño resumen se enumerarán las distintas opciones que posee el programa y también servirá como manual de uso para su funcionamiento correcto.


- - - - - - - - - - - - - - - - - - - - - - - - - DESCRIPCIÓN GENERAL - - - - - - - - - - - - - - - - - - - - - - - - -

Dicha aplicación posee 6 botones, que se muestran en la parte izquierda del programa.
1. El botón "Load File" sirve para cargar los ficheros que desee el usuario (un máximo de dos fichero en la simulación). 
2. El botón "Select Time" permite seleccionar el período de tiempo de interés dentro del rango de horas del fichero cargado.
3. Un botón "Data View" que permite ver una tabla con todos los datos y con distintas opciones que más adelante se detallarán. 
4. Un botón "Map View" que ofrece al usuario un mapa que muestra los movimientos de las aeronaves y así como de vehículos terrestres. También ofrece distintas opciones para su configuración.
5. Un botón "Clear File" que elimina los ficheros anteriormente cargados.
6. Por último, un botón de "Exit" que permite al usuario cerrar el programa.

Esta aplicación ha sido optimizada para un funcionamiento y rendimiento correctos.


- - - - - - - - - - - - - - - - - - - - - - - - - LOAD FILE - - - - - - - - - - - - - - - - - - - - - - - - - 

Primeramente, una vez ejecutado el programa, se mostrará la pantalla de bienvenida, con el logo de AsterixDecoder en su centro. Para iniciar el programa se debe clicar el botón de "Load File", dónde se abrirá el explorador de archivos de su ordenador y deberá seleccionar el archivo con un doble clic o con el botón abrir.

Si usted selecciona anteriormente a este paso cualquier otro botón se le mostrará en pantalla un mensaje de que aún no se ha seleccionado un archivo.

Como máximo se pueden cargar dos ficheros simultáneamente (haciendo dos veces el proceso, no a la vez) y tienen que ser de la misma hora. 

Hay distintos filtros a la hora de cargar el fichero para detectar si el segundo archivo cumple con el rango de horas del primero o si se está intentando cargar el mismo archivo por equivocación. Si el archivo que se intenta subir no es de datos ASTERIX o de una categoría distinta a las analizadas, salta un mensaje diciendo que no lo puede decodificar.


- - - - - - - - - - - - - - - - - - - - - - - - - SELECT TIME - - - - - - - - - - - - - - - - - - - - - - - - - 

Una vez se ha cargado correctamente el archivo, el programa muestra un mensaje de texto con el nombre del fichero cargado y la hora inicial y final. Debajo se encuentran unas cajas de texto en la cual hay que escribir la hora inicial y final de interés. Estos campos tienen unos filtros corrigiendo el formato de entrada por el usuario y también si hay incoherencias en las horas establecidas (por ejemplo que se encuentren fuera del intervalo, la inicial sea mayor que la final, etc.).

Debido a que los archivos tienen una enorme cantidad de datos, y no es posible decodificar todo el fichero entero, se ha puesto una limitación de una ventana de 30min. Excepto un tipo de archivos, los que tienen datos radar de superficie (CAT010 y CAT021), que sí que se permite seleccionar todo el rango de tiempo del fichero, ya que el volumen de datos es menor (son ficheros de 2 horas a diferencia de los de ruta que son 4 horas).

Una vez seleccionadas las horas, se pulsa al icono de la lupa y empieza a decodificar los mensajes del fichero. Dependiendo del intervalo introducido, tardará más o menos en decodificar todos los datos. Una vez finalizado, se muestra un mensaje indicando que se ha realizado con éxito y muestra el número de paquetes decodificados.

También existe la posibilidad de cambiar el período de tiempo a analizar en cualquier momento, por si al usuario le interesa estudiar otro momento dentro del período de tiempo del fichero.


- - - - - - - - - - - - - - - - - - - - - - - - - DATA VIEW - - - - - - - - - - - - - - - - - - - - - - - - - 

Una vez se ha cargado el archivo a analizar, se puede mostrar su información en formato tabla. Para eso clique el botón "Data View" del menú que se muestra a su izquierda. Verá en formato tabla, en la cual la cabecera de indica el campo de esa columna, toda la información que se ha decodificado, mostrando un N/A en los casos en que no se dispone de esa información para ese archivo y un "Click to see info" o en algunas celdas detrás del dato hallará un asterisco (*) indicando que si pulsa en esa celda se mostrará en una ventana adicional toda la información que debido a su gran tamaño no se muestra en la pantalla inicial.
 
Para facilitar la búsqueda de determinados paquetes que puedan ser de interés por el usuario, debido al gran número de paquetes que hay en cada fichero y que se encuentran ordenados numéricamente, se ha incorporado un buscador situado en la parte superior. El usuario deberá clicar en una de las opciones que se ofrecen para poder filtrar por ese campo, escribir el paquete a buscar en el cuadro de texto y pulsar al icono lupa o mediante la tecla Intro. Si el paquete no ha sido encontrado se visualizará el cuadro de texto de color rojo. Y también se mostrará en cada búsqueda el número de paquetes que han sido filtrados, situado en la esquina superior derecha.

Además, otra opción de búsqueda más dinámica, sin tener que usar el cuadro de texto, es la siguiente: Al clicar en algún elemento de la tabla, si éste está habilitado para ser filtrado, automáticamente se filtrarán los paquetes que contengan ese campo en concreto, viendo como se autocompleta el campo cuadro de texto con ese elemento seleccionado y se marca de manera instantánea el check box del campo referido.

Para poder filtrar de manera más precisa, hay la posibilidad de hacer filtros encadenados si se selecciona el checkbox llamado “Chain Filters”. Así permite buscar al usuario grupos de mensajes muy concretos.

Para volver a ver la totalidad de los paquetes, haga clic en la flecha de restaurar que hay al lado del buscador.

Otra funcionalidad que permite es generar un fichero CSV a partir de los datos que se encuentran representados en ese momento en la tabla (con o sin filtros). Para obtener este fichero, que se guarda en la carpeta de descargas del  usuario, se tiene que pulsar el icono que tiene una hoja con las siglas CSV y luego el programa te permite abrirlo directamente.


- - - - - - - - - - - - - - - - - - - - - - - - -  MAP VIEW - - - - - - - - - - - - - - - - - - - - - - - - - 

En este botón se muestra la parte gráfica de todos los datos, es decir el movimiento de las aeronaves y vehículos de tierra en una aplicación Maps de Google. Se puede personalizar la interfaz gráfica del mapa, pudiendo cambiar la vista a satélite en el botón "Layout", cambiar el zoom al gusto del usuario mediante el scroll del ratón encima del mapa o con la barra del zoom situada debajo.

Para iniciar la simulación completa de todas las aeronaves, el usuario debe seleccionar el botón "All Flights" y seguidamente clicar el botón "play" para ver la simulación en el Maps. Se mostrarán las aeronaves representadas en puntos de distintos colores cada uno de ellos refiriéndose al tipo de sistema de vigilancia por el cual ha sido captado. Estos datos están detallados en la leyenda que hay en la parte superior.

En el lado izquierdo del mapa se ve una tabla donde se detallan en cada instante de la simulación que aeronaves están presentes y unos datos relevantes de cada una (CallSign, ICAO Address/Track Number, Mode 3/A y número de sensores). Si se pulsa encima de un avión se mostrará su estela, en color azul, de todo el recorrido que realizará.

Para pausar la simulación hay que hacer click en el botón "Pause" y para reanuadar volver a darle al "Play". Y para restaurar la simulación y volver al inicio pudiendo volver a ejecutarla o cambiar a otros parámetros, hay que darle al botón cuadrado "Stop".

Finalmente, hay distintas opciones que ofrecen al usuario una experiencia más completa:

1.	Se puede mostrar únicamente un solo vehículo haciendo clic en la columna de "CallSign" y clicando "play" seguidamente. Una vez se muestra el avión en pantalla, aparece una tabla informativa con los datos más relevantes de ese avión y se puede clicar en cualquier sitio de la tabla y aparecerá todo el recorrido que realizará el avión del color correspondiente al tipo de pista y su posición actual en azul.

2.	Se puede hacer un filtro por distintos tipos de campos como sería mostrar únicamente la categoría o por el sensor deseados, seleccionándolos en las respectivas columnas “Category” o “Radar Station”.

3.	Se permite seleccionar la hora de inicio de la simulación (fragmentada en bloques de 1 minuto) cuando haya más de un avión a simular, seleccionándose en la columna "Initial Time".

4. 	Se pueden visualizar y esconder elementos del espacio aéreo, como aeródromos, ATZ, CTR, CTA, TMAs, sectores SACTA, aerovías, SIDs y STARs, seleccionando los checkboxs que se encuentran en la parte superior del mapa. Tanto las aerovías, SIDs y STARs, si el checkbox “Tag” está seleccionado, si se pulsa a una línea aparece el nombre de ese elemento. En el caso de las TMAs y sectores SACTA, si el “Tag” está marcado aparecerá dentro de ese volumen el nombre. 

5.	El botón "Plot all" muestra todos las pistas radar de todos los aviones o vehículos en el mapa, cada plot representado con su código de colores. 

6.	Se incorporan las opciones para incrementar la velocidad de la simulación, ofreciendo velocidades x2, x4, x8 y x16. 

7.	Se puede configurar la largada de la estela (desde 1 hasta 10) de pista monoradar en la parte superior dónde aparece "Flight Trial". Por defecto, la largada de la estela está configurada en tres plots.

8.	En cualquier momento que se muestren gráficamente las aeronaves en el mapa, se puede poner el cursor encima de los puntos y se mostrarán los datos más significativos de ese blanco (hora UTC, CallSign, ICAO, Track Number, Modo 3/A, FL).

9.	En cualquier momento de la simulación (una vez seleccionado(s) la(s) aeronave(s), durante o una vez terminada) se puede(n) exportar el/los recorrido(s) de la(s) aeronave(s) en un archivo KML clicando en el botón "KML" que se generará en la carpeta de descargas del usuario. Se abrirá una ventana emergente preguntándole si desea visualizar el archivo en Google Earth y si acepta se abrirá la aplicación donde verá en 3D el recorrido de los aviones. Si desea ver el perfil vertical de una ruta, debe hacer click en ella con el botón derecho y seleccionar "Mostrar perfil de elevación".


- - - - - - - - - - - - - - - - - - - - - - - - - CLEAR FILE - - - - - - - - - - - - - - - - - - - - - - - - - 

Este botón permite eliminar los ficheros cargados previamente en cualquier momento. Se abrirá una ventana emergente de confirmación de cierre. Así facilita el estudio de varios ficheros ASTERIX sin la necesidad de abrir y cerrar el programa cada vez que se quiera analizar un escenario nuevo.


- - - - - - - - - - - - - - - - - - - - - - - - - EXIT - - - - - - - - - - - - - - - - - - - - - - - - - 

Hay dos manera de salir del software. Una es mediante el botón en forma de cruz situado en la parte superior derecha. Si se pulsa ese botón se muestra una ventana emergente que pregunta al usuario si desea cerrar el programa o por lo contrario había sido un error y quiere seguir explorando.

Otra es mediante el botón del menú vertical llamado “EXIT”, que al ser pulsado se despliega debajo la misma pregunta que con la ventana emergente de confirmación de cierre. Si se desplaza a otra pestaña sin verificar la respuesta, el desplegable se esconde automáticamente.


- - - - - - - - - - - - - - - - - - - - - - - - - CONTACTO - - - - - - - - - - - - - - - - - - - - - - - - - 

Para cualquier otra duda o pregunta, puede usted contactar con paabloop98@gmail.com

