# Pruebas Nicolas Salinas Galindo

Se desarrolla aplicación web en Angular 12.2.16 y
servicio API en .NET 5.0


## EVIDENCIAS

Se adiciona evidencias de funcionamiento de la aplicación:



## ARQUITECTURA

Se desarrolla una arquitecutra cliente servidor, donde el proyecto web es independiente al proyecto API, a continuación se muestra un diagrama por componentes, posteriormente se explican estructuras de los proyectos de forma indepndiente.

![image](./Documentacion/Markdown/DiagramaComponentes.png)

## NET CORE 5.0 API (CryptocurrencyPrice)

La solución se estructuro por capas para que sea altamente mantenible y desacoplada, se crearon las sigueintes capas:

### __Estructura de proyecto API__

![image](./Documentacion/Markdown/EstructuraAPI.png)

* __Api__\
Es la capa que se expone al cliente la cual contiene los controladores a exponer, para esta solución se implementaro validación de excepciones y ApiKey de manera generica con el fin de poder ser reutlizado en toda la solución, tambien se adiciono docuemntación por medio de swagger. A continuación se muestra la documentación:

![image](./Documentacion/Markdown/DocumentacionAPI.png)

* __Business__\
Es la capa encargada de la logica de negocio, para este proyecto lo unico que hace es conectarse a la capa de Coinmarketcap para consultar los datos ya que no hay validaciones o logica adicional para los metodos.

* __Entities__\
Es la capa que continee las entidades necesarias para mapear la información y retornar los datos, para esta solución no hay entidades de negocio, por lo que se optó por categorizar las clases de la siguiente manera:
  * MP (Method Parameters): Son los parametros de entrada y salida de los metodos del API.
  * VM: (Virtual Model): Son las modelos virtuales para mapear información interna que se quiere devolver en el servicio.

* __Utilities__\
Es la capa de utilidades, esta se usa para generar funciones genericas que se necesiten a lo largo de la solución, para este caso unicamente se tiene una función de consumo generico de servicios por metidio de GET.}

* ExternalServices\
Se crea esta carpeta para adicionar los proyectos que consuman servicios externos, para este proyecto solo consumimos Coinmarketcap.
  * __Coinmarketcap__
  Es la capa con la logica de negocio para consumir y mapear a nuestra solución la información retornada por el [API de Coinmarketcap](https://coinmarketcap.com/api/documentation/v1/).

### __CONFIGURACIÓN__

Se adiciona configuración en el archivo Appsettings.json en el proyecto CryptocurrencyPrice.Api para setear los datos de Coinmarketcap y el ApiKey.

* Coinmarketcap:
  * ApiURL: Indica la dirección del servicio de Coinmarketcap, para esta configuración se encuentra apuntando a test.
  * ApiKey: Llave de Coinmarketcap
  * HeaderApiKeyName: Nombre del header que recibe Coinmarketcap para el ApiKey
* ApiKey: Api Key interna para validación de header de los clientes que cosnumen el servicio.

```json
{
  "Coinmarketcap": {
    "ApiURL": "https://sandbox-api.coinmarketcap.com/v1/",
    "ApiKey": "b54bcf4d-1bca-4e8e-9a24-22ff2c3d462c",
    "HeaderApiKeyName": "X-CMC_PRO_API_KEY"
  },
  "ApiKey": "6f28ca3a-3007-482b-90d1-a03f8ad887aa"
}
```

## ANGULAR 12.2.16 (CryptoCurrencyWeb)

### __Estructura de proyecto Web__

 ![image](./Documentacion/Markdown/EstructuraWEB.png)

Se creo el modulo "cryptocurrency" para adicionar los componentes que tengan que ver con la información de las criptomonedas, y el modulo "shaere" con el fin de poner los componentes genericos de la aplicación.

### __CONFIGURACIÓN__

En adiciona configuración en los archivos de enviroments para setear la información según necesidad.

* ApiUrl: Api del servicio desarrollado en .NET CORE 5.0 (CryptocurrencyPrice).
* ApiKey: Key del servicio, este debe coninsidor con el dato de Appsetting.json del servicio.
* DefaultCryptocurrenciesList: Lista separada por "," con los simbolos de las criptomonedas a consultar las últimas cotizaciones. 

```typescript
export const environment = {
  ApiUrl: "https://localhost:5001/api/", 
  ApiKey: "6f28ca3a-3007-482b-90d1-a03f8ad887aa",
  DefaultCryptocurrenciesList: "BTC,ETH,BNB,USDT,ADA"
};
```