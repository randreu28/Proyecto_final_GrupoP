# **Entorns Virtuals - Proyecto final -  Grupo P**

Bienvenido a nuestro proyecto de unity! Ha sido creado como un proyecto de universidad para la clase de entornos virtuales.  Puedes encontrar el repositorio en [Github].

Nuestro proyecto consiste en un lobby principal con 4 portales a las cuatro diferentes escenas. A continuación ciertas anotaciones de cada escena para el profesorado:

### **Escena lobby**
Puntos que toca la escena:
- Programming
- Particulas sin interación
- Shaders propios
- Extra (Postprocesado)
>El mapa y sus texturas bakeadas fueron creadas por nosotros.

### **Escena Shooter Western**
Puntos que toca la escena:
- Programming
- Physics
- Terrain
>En la entrega 2 se ha hecho el terrain con vegetación
- Instantiating y Particles
> Al morir, el enemigo suelta particulas para simular sangre. Al disparar también instancia particulas a modo de muzzle flash
- Audio
> Cuando te acercas, hay una música más frenética. Sonido de disparo, muerte, restar vida.
- AI
> El enemigo tiene tres estados. Patrulla, detección y caza ( va a por ti y te dispara). 
- Extra
> Hay una animación en el arma del protagonista (retroceso y sway).

> Cuando la bala del enemigo impacta sobre el protagonista, aparece un efecto de daño/sangre sobre la pantalla. 
>El mapa, los trajes de los enemigos y los modelos 3d de las armas, son descargados de internet.

### **Escena Sci Fi**
Puntos que toca la escena:
- Lights
> Se han añadido un baked map, con Light Probes en la sala del drone. (El drone como dynamic object) y una luz dinámica (Detección de cámaras) 
- Programming
>El mapa es un asset de unity, pero fue rediseñado para utilizar nuestra iluminación (probes, reflexiones). Los scripts de la puerta y el audio son del propio asset, sin embargo los scripts y el modelado de las camaras son propios.

### **Escena Plataformeo**
Puntos que toca la escena:
- Shaders
> Se ha creado un shader propio de Agua
- Programming
> Se ha creado un sistema de muerte con diferentes spawnPoints
> Se ha creado un script de plataformas trampa con probabilidad
- Animations (plataformas)
- Extra
>El mapa y props son descargados de internet. El rig y animaciones se han adaptado a nuestro caso particular.

### **Escena Titanfall**
- Instantiating
> El mapa es totalmente procedural. Hay diferentes tipos de coleccionables, con variables de probabilidad distintas.
- Audio
> Se utilizó unos audios preparados para FMOD para crear stages sonoros. A medida que aumentas el score, la música iba progresando. El sonido de los coleccionables cambia el pitch en base a la cantidad recolectada. También hay audios varios como el botón, reducción de puntos y los fireworks. 
- Particles
> Aparece un sistema de particulas con subEmitters tras superar los 50 puntos, cuyos valores de color pueden ser modificados en base a la interacción de un botón. (Hace un ciclo entre variables de gradientes públicos).

> Al colectar una moneda rara crea un sistema de partículas a modo de efecto visual.
- Programming
> Sistema de collecionables escalable.

Esperamos que os haya gustado tanto como a nosotros nos a gustado crearlo!

[Github]: <https://github.com/randreu28/Proyecto_final_GrupoP>
