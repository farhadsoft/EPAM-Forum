# Web project topic : Forum

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=farhadsoft_EPAM-Forum&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=farhadsoft_EPAM-Forum) [![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=farhadsoft_EPAM-Forum&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=farhadsoft_EPAM-Forum) [![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=farhadsoft_EPAM-Forum&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=farhadsoft_EPAM-Forum) [![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=farhadsoft_EPAM-Forum&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=farhadsoft_EPAM-Forum) [![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=farhadsoft_EPAM-Forum&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=farhadsoft_EPAM-Forum) [![Bugs](https://sonarcloud.io/api/project_badges/measure?project=farhadsoft_EPAM-Forum&metric=bugs)](https://sonarcloud.io/summary/new_code?id=farhadsoft_EPAM-Forum)

## Functionality

Standard operations inherent in any forum - adding topics, messages for usual users. Moderation of records, working with forum users for moderators and admins.

## Requirements for the project

Architecture requirements

Backend part - 3-layer or onion architecture with low coupled data access layer (DAL), business logic layer (BLL), presentation layer (PL) At least 3 projects are required.

 Layers&#39; content:

- DAL – EF code first, migrations, Repository &amp; UOW are applied
- BLL – several services with applying DI and IoC, mapping, authentication based on Identity
- PL – RESTful web api (or MVC)

Frontend part (optional) – html &amp; CSS, JS or typescript

Data store requirements

Store information about the subject area in the database, use Entity Framework Code First for access. Use MS SQL as a DBMS

Code requirements

- Provide validation of user input.
- The code should be organized so that it can be reused and relatively easy to replace the implementation of logical parts.
- Provide error handling.
- Follow clean code rules - the internal organization and structure of the project code will be assessed no less carefully than the external compliance of the project with the task.
- Code styling must comply with the C # Code Conventions (MSDN).
