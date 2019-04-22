Author:
- Jose Angel Naranjo García

Pequeño proyecto, a modo de prueba de conceptos, donde intento dar un enfoque orientado a los principios SOLID.

Quizás la funcionalidad del mismo es lo que menos en sí, pero para que la teoría se aplique a un supuesto real, he visto interesante implementar este proyecto.

# Tags y Requisitos

* Aplicación WEB / .NET / C# / REST / Swagger / IIS Express
* No utiliza Base de datos, la persistencia se simula en memoria. (No descarto implementar persistencia con base de datos) 
* Visual Studio 2017

# Funcionalidad 

## Se parte de ..

La aplicación consiste en un pequeño módulo que se encarga del suministro de productos a los trabajadores.

Se parte que el sistema tiene almacenado:

 * La información de la definición de productos (Product) que pueden ser suministrados.
    Se tendrán definidos productos y paquetes
    
 * Lugares de trabajo (WorkPlace)
 
 * información de los trabajadores (Worker)
 
 * Habrá un Stock de productos a poder ser suministrado y dará juego para nuevas restricciones

## Funcionalidad del módulo ..
  
 * Mostrar los productos suministrados a un trabajor por espacio de trabajo
 * Configurar los productos que se puedan suministrar a un trabajor en un espacio de trabajo
 * Suministrar productos y paquetes a trabajadores cuando tienen una relación laboral con alguno de los lugares de trabajo definido en el sistema.
 * Se puede definir la cantidad de productos por cada trabajador y lugar de trabajo

 
 (..se completara esta sección a medida que se complete el desarrollo)
 
# Diseño Software

Real justificación de este proyecto. Principios SOLID resumido en

S - Single-responsiblity principle.
O - Open-closed principle.
L - Liskov substitution principle.
I - Interface segregation principle.
D - Dependency Inversion Principle.

(..se completara esta sección: con la filosofía de desarrollo, justificación de patrones usados, el cómo se reflejan algunos de los principios SOLID a mi modo de entenderlos )

