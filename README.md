# Capibara.Enterprise

Habbo emulator written in c#.

### Project Structure

- Presentation

It does include everything exposed, like Revisions headers/packets, Sockets/WS implementations and etc

- Networking

Shared API's between presentation layer, and packet handling

- Infrastructure

All services implementations, such as database and others third-party libraries.

- Core
    - API: describes all types which core project does implement to make game work

\
\
Each layer need have an API project, which will expose types internally implemented and injected in IoC container.