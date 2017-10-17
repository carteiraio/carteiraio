FROM microsoft/aspnetcore:2.0
LABEL name docker-carteira-io
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "CarteiraIO.Api.dll"]
