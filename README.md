# Palvkerings-oppgaven

## Hvordan komme i gang
Om man kjører applikasjonen fra host-mappa, så skal løsningen kunne åpnes på http://localhost:5000
``` shell
cd src/Alv.Parkering.Host
dotnet run
```


## Endepunkter

### http://localhost:5000/parkingspot?page=0&pageSize=25
``` json
[
    {
        "address": "\u00d8vre Langgate 28",
        "freeParkingCount": 10,
        "paidParkingCount": 0,
        "charingSpotCount": 0,
        "handicapSpotCount": 0,
        "handicapDescription": "Det er vurdert at dette er en for liten og trang plass til å kunne tilrettelegge HC plass ihht kravene om utforming og st\u00f8rrelse. Det er kommunale HC plasser i nærheten (Conradisgt og Klostergaten)."
    }
]
```


### http://localhost:5000/parkingspot/all
``` json
[
    {
        "address": "\u00d8vre Langgate 28",
        "freeParkingCount": 10,
        "paidParkingCount": 0,
        "charingSpotCount": 0,
        "handicapSpotCount": 0,
        "handicapDescription": "Det er vurdert at dette er en for liten og trang plass til å kunne tilrettelegge HC plass ihht kravene om utforming og st\u00f8rrelse. Det er kommunale HC plasser i nærheten (Conradisgt og Klostergaten)."
    }
]
```
