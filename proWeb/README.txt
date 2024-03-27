1. Cosas tienes que hacer
	- No lo he hecho las restricciones para los datos que introduce por el usuario;
	- No lo he hecho las comprobaciones que los datos son correcto or no.
	- ID de la tabla Products se aumenta cada veces que ejecuta a Create. Cuando falla tambien se aumenta, no sé el el aumento es correcto or no. Hay que revisar
	- Error cuando F5. Hay que arreglar en Site1.Master.cs

2. Para consultar en el SQL
	-select * from Products right join Categories on Categories.id = category order by creationDate;