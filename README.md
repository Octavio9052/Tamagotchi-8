# Descripción General

El objetivo central es crear una plataforma integral para hacer funcional el juego de Tamagochis. Esta plataforma deberá comprender una aplicación móvil, dos servicios web, una aplicación web y por ultimo una aplicación de escritorio.

Cada uno de los entregables estará explicado a detalle. La arquitectura se debe cumplir como esta a nivel macro en la definición propuesta. Las restricciones también deben ser cumplidas y no hay negociación de cambio al respecto.

La comunicación que debe darse entre cada componente debe ser la especificada en la arquitectura sin excepción: 

## Entregables

**Servicio REST:** Debe ser probado mediante cualquier herramienta como fiddler, postman o cualquier otra herramienta que sea de su preferencia.

**Servicio SOAP:** Debe ser probado mediante cualquier herramienta como fiddler, postman o cualquier otra herramienta que sea de su preferencia.

**Interface del desarrollador (aplicación de escritorio):** 
![Bosquejo de la aplicación de escritorio](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/tw01.png)
Algunos puntos extras pueden ser obtenidos:
* 1-3 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/tw_d01.png)
* 4-8 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/tw_d02.png)
* 9-15 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/tw_d03.gif)

**Tienda virtual (aplicación web):**
![Bosquejo de la aplicación de escritorio](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/ts01.png)
![Bosquejo de la aplicación de escritorio 2](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/ts02.png)
![Bosquejo de la aplicación de escritorio 3](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/ts03.png)
Algunos puntos extras pueden ser obtenidos:
* 1-3 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/TS_D01.png)
* 4-8 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/TS_D02.png)
* 9-15 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/TS_D03.png)

**Juego (aplicación móvil):**  
![Bosquejo de la aplicación móvil](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/T01.png)
![Bosquejo de la aplicación móvil](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/T02.png)
![Bosquejo de la aplicación móvil](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/T03.png)
![Bosquejo de la aplicación móvil](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/T04.png)
![Bosquejo de la aplicación móvil](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/T05.png)
Algunos puntos extras pueden ser obtenidos:
* 1-3 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/Tamagochi_D02.png)
* 4-8 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/Tamagochi_D03.png)
* 9-15 puntos. [Ejemplo](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/Tamagochi_D01.png) 

## Arquitectura  
La figura siguiente muestra la intención de la arquitectura que debe tener el entregable, ya que debe contar con cada bloque ahí mostrado, al igual que la comunicación debe darse entre los componentes y capas según se indica ahí mismo.  
![Diagrama de arquitectura](http://xpesdcompany-001-site3.ctempurl.com/sites/cetys/clases/sd/Architecture.PNG)  

## Restricciones  
Cada una de las partes debe ser construida en las tecnologías que se especifican a continuación, la libertad de selección está establecida de acuerdo al grupo en el que se encuentra.  
* **Escritorio:** Java, Winform, WPF.  
* **Web:** ASP.NET|JSP|PHP, Struts|MVC, Angular|JQuery.  
* **Móvil:** Android, Windows Store, iOS.  
* **Servicios:** Nodejs, Java, .NET

## Criterios de Evaluación  
* **Escritorio** *20%*  

| Aspecto	       | Valor	       |
| -------------- |:-------------:|
| Usabilidad     | 20		         |
| Excepciones    | 20		         |
| Implementación | 60	           |

* **Móvil** *20%*  

| Aspecto	       | Valor	       |
| -------------- |:-------------:|
| Ergonomía	     | 20		         |
| Responsividad	 | 20		         |
| Excepciones 	 | 10	           |
| Implementación | 40		         |
| Diseño 	       | 10            |

* **Web** *20%*  

| Aspecto	       | Valor      	 |
| -------------- |:-------------:|
| Adaptabilidad	 | 20		         |
| Responsividad	 | 20		         |
| Excepciones 	 | 10	           |
| Implementación | 40		         |
| Diseño 	       | 10		         |

* **Servicio SOAP**  

| Aspecto	       | Valor	       |
| -------------- |:-------------:|
| Diseño API 	   | 35	        	 |
| Excepciones    | 20		         |
| Implementación | 35	           |
| Hospedaje 	   | 10	           |

* **Servicio REST**  

| Aspecto	       | Valor	       |
| -------------- |:-------------:|
| Diseño API 	   | 35	        	 |
| Excepciones    | 20		         |
| Implementación | 35	           |
| Hospedaje 	   | 10	           |
