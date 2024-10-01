## Generalidades
- El proyecto en general continia errores de compilación.
- El proyecto fue guardado en Unity 5 por lo cual no coincide con el editor iniciado (2022.3.48f1).
## Detalles Especificos
- Faltaba instalar la Unity.UI, esto fue resuelto instalando el paquete en el package manager
- En en PlayerController al iniciar la funcion start (La que se encarga de ejecutar acciones en el primer frame)  destruia/borraba el script impidiendo el movimento, asi como tambien la vida del personaje iniciaba en 0.  Se agregaron los codigos de MovePlayer y ShootBullet que hacen refencia al movimiento del personaje y al presionar click izquierdo disparar una bala respectivamente.
- Del lado de los enemigos no todos contaban con un playerController, esto impedia eliminar a todos los aliens, no todos los enemigos tenian el tag de "Enemy" que es fundamental a la hora de eliminarlo. Se creó un codigo para el enemigo, puesto que este necesitaba una vida y una funcion Destroy para que al no tener vida el object sea eliminado.
- En el codigo de la bala no tenia encuenta el tiempo de vida, es decir, la bala estaría permanentemente al momento de aparecer, y tampoco tenia la logica de que pasaría si hiciera contacto con un objeto que tenga el tag de "Enemy
