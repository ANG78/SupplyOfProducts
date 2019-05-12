## Requisitos de información y funcionales 

La aplicación (Backend) se encargará de la gestión de:

* la configuración del suministro de productos o paquetes a trabajadores
* la solicitud de productos o paquetes por parte de los trabajadores
* Lugares de trabajo (WorkPlace) 
* información de los trabajadores (Worker)

# Requerimientos (a día de hoy) fuera del alcance del módulo

 * La información de la definición de productos (Product) que pueden ser suministrados.
    Se tendrán definidos productos y paquetes de productos.
  
 * La relación entre Worker y los WorkPlaces, vendrá configurada por 
 
   * fecha de Comienzo de la pertenencia al centro de trabajo
   * fecha de finalización de pertenencia
   * Número de años por Periodo de Suministro.

 *  La fecha de comienzo del vínculo de un trabajador con un centro de trabajo, vendrá definido por las fechas Comienzo y Finalización. Esto define un rango, en el cual el trabajador pueda solicitar nuevos productos o paquetes de productos.

 * La fecha de comienzo y el "número de años por Periodo" definirá un Periodo de suministro, en el cual el trabajador podrá solicitar una cantidad de productos que previamente será programada en el sistema. Cada periodo será representado por la fecha inicial de cada uno de ellos.

 * Habrá un Stock de productos, el cual se tendrá en cuenta para poder aceptar una petición de solicitud de un producto.


## Alcance del módulo
  
 * Mostrar los productos suministrados a un trabajador y por espacio de trabajo

 * Configurar los productos que se puedan suministrar a un trabajador en un espacio de trabajo

 * Suministrar productos y paquetes a trabajadores cuando tienen una relación laboral con alguno de los lugares de trabajo definido en el sistema.


 # Ejemplo

 Con el siguiente ejemplo se puede tener una visión de lo que pretende implementarse en el módulo. 
 
 Un trabajador (W01) vinculado a un centro de trabajo (WP01) con 
 
      * fecha de comienzo 1/1/2010
      * fecha de finalización 1/10/2016
      * numero de años por ciclo: 2

 Se le configurará el siguiente suministro para los dos primeros periodos del vínculo W01 - WP01:

      * Paquete de productos (EPI5), compuesta por casco (EPI1), guantes(EPI2) y botas (EPI3) para cuando pertenezca al lugar de trabajo (WP01), con una cantidad máxima de 1 por periodo

      * El trabajador podrá solicitar adicionalmente productos por separado.
        2 pares de guantes (EPI2)
        1 par de botas (EPI3)

Con esta programación de suministro, el trabajador WP01 podrá hacer lo siguiente.

En el primer periodo, que comienza en 1/1/2010 solicitó: 1 EPI5, 1 EPI2 y 1 EPI3

En el siguiente periodo, que comienza en 1/1/2012 pudo volver a solicitar: 1 EPI5, 1 EPI2. intentó solicitar un par de gafas (EPI4) pero el sistema le denegó la petición, al no tener configurado dicha EPI en el sistema.

Más adelante, el 1/12/2017 el trabajador intenta solicitar un nuevo par de guantes (EPI2), pero el sistema le deniega la petición pues no pertenece ya al lugar de trabajo (WP01).


Por otro lado, cuando se esta configurando el suministro de un trabajador en un centro de trabajo, se tienen que comprobar que en la fecha de solicitud, dicho vínculo esté vigente. Además, la configuración se hará por periodos de suministro.
