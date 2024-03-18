# advanced-swe

## Clean Code Architecture

### Plugins
- DB (Niklas)
    - SQL DB
    - Mongo DB
    - Postgres
    - CSV
- Test (Niklas & Benjamin)
    - Unit Test
    - Integration Test

- (GUI)

### Adapter
- Api Endpoint (Benjamin)
    - FlightService
        ```json
        POST {
            "FlightNr", "CarrID", "ConnectionID", "StartZeit", "Endzeit", "FlightMeal"
        }
        ```
    - Booking Service

- Store (Niklas)
    - StoreController
    - DbController
        - Liste an Connections
    - Query <T : Idb>
    - DbFlight -> Beziehung als String
    - DbCarrier
    - DbConnection

- Repositories (Niklas)
    - RepositoryManager -> Map(Type, Repository<Type>)
    - FlightRepository -> Query<DbFlight>
    - Repository<Carrier>
    - Repository<Connection>
    
### Application 
Manager (Benjamin)
    - FlightManager
        - CreateFlight("flightNr", carrObj, flightMenObj, "startDate", "endDate")
        - UpdateFlight()
    - CarrierManager
        - AddConnection(carr, conn)
            -> carr.add(conn);

### Domain (Benjamin)
- Flights -> Beziehungen als Objekte
- Carrier
- Connection