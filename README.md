# Introducción

Este documento proporciona una guía detallada para implementar el SDK de OWO dentro de Unity. La guía está diseñada para ayudar paso a paso para poder configurar de manera adecuada el SDK, crear sensaciones y poder enviarlas a la aplicación de OWO.

----

# Primeros pasos
1. Descargar Unity
2. Crear un nuevo proyecto
3. [Importar el SDK de OWO](https://assetstore.unity.com/packages/tools/integration/owo-integration-180991 "Descargar el SDK de OWO")


---
## Inicialización del Plugin

Una vez importado el package de OWO, un archivo con el nombre OWO.dll aparecerá en **Assets/Plugins/OWO**

Para acceder a las clases del SDK, es necesario utilizar el namespace de ***OWOGame***.

Para eso, agregamos esto al principio de nuestro codigo.

    using OWOGame;

---
## Conexión con OWO
Hay dos formas de establecer una conexión con OWO:
- **Conexión Manual:** El usuario debe ingresar la IP que le proporciona la aplicación de OWO al presionar el botón ***Play***. Para establecer esta conexión, debes usar la función Connect de la clase ***OWO***.

```csharp
OWO.Connect(ip);
```

- **Conexión automática:** A través de la función ***AutoConnect***, la clase ***OWO ***comenzará a buscar la aplicación de OWO a través de la red local y establecerá una conexión.

```csharp
OWO.AutoConnect();
```
---
#### Desconexión
Puedes llamar al método ***Disconnect*** de la clase ***OWO*** para dejar de recibir sensaciones.

```csharp
OWO.Disconnect();
```
---
#### Escaneo de IP
Al llamar al método ***StartScan***, la API comenzará a buscar aplicaciones de OWO cercanas y almacenará los resultados en la propiedad ***DiscoveredApps*** de la clase ***OWO***

---
#### Conexión a multiples dispositivos:

Es posible conectarse a varias aplicaciones OWO al mismo tiempo de la siguiente manera:

```csharp
OWO.Connect(ip1,ip2,ip3...);
///Si hiciste un escaneo previamente:
OWO.Connect(OWO.DiscoveredApps);
```
---
## Crear sensaciones
Es posible crear sensaciones utilizando el [Sensations Creator](https://owo-game.gitbook.io/unity-engine/tools/sensations-creator "Sensations Creator") de OWO, pero también es posible crearlas por código.

##### Crear una sensación y guardarla en una variable

```csharp
Sensation sensation = SensationsFactory.Create(100, 0.1f, 100, 0, 0, 0);
```
Cada uno de los parametros se refiere a:

1. Frecuencia (hz)
2. Duración (segundos)
3. Intensidad (%)
4. Entrada (segundos)
5. Salida (segundos)
6. Tiempo de salida (segundos)

##### Asignar musculos a una sensación existente
```csharp
sensation.WithMuscles(Muscle.Pectoral_R);
```
Esta línea de código genera una nueva ***SensationWithMuscles***, una vez que el musculo se ha asignado a una sensación, no cambiará, será necesario crear una nueva ***SensationWithMuscles***.

---

#####Modificar el porcentaje de intensidad del grupo de musculos asignados

```csharp
sensation.WithMuscles(Muscle.All.WithIntensity(70));
```

Es posible cambiar la intensidad de un solo musculo, un grupo de musculos o incluso un grupo de musculos con intensidades difirentes por musculo.

```csharp
sensation.WithMuscles(Muscle.Arm_L.WithIntensity(20), Muscle.Arm_R.WithIntensity(5));
```

---

##### Juntar una o más sensaciones para crear una cadena de sensaciones

```csharp
sensation.Append(sensation2);
```

Esto resulta en una combinación de ambas sensaciones.

---

## Enviar sensaciones
Una vez que se haya establecido la conexión, puedes enviar sensaciones con el método ***Send*** de la clase ***OWO***.

```csharp
OWO.Send(sensation);
```

Puedes optar por agregar una priodad a una sensación, esto hace que ninguna otra sensación pueda ser enviada hasta que la sensación actual haya terminado, o que se envíe una de la misma o mayor prioridad.

```csharp
sensation.Priority = 1;
OWO.Send(sensation);
```

---

## Importar sensaciones

Facilmente puedes importar los archivos .owo generados utilizando el [Sensations Creator](https://owo-game.gitbook.io/unity-engine/tools/sensations-creator "Sensations Creator") de OWO a tu proyecto abriendo el archivo y copiando sus valores.

Luego, ve a tu proyecto y simplemente pega el string donde es necesario.

```csharp
Sensation sensation2 = Sensation.Parse("0~Ball~100,1,90,0,0,10,|0%100~impact-0");
```


