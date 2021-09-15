FROM mcr.microsoft.com/dotnet/sdk:5.0
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet tool install --global dotnet-ef --version 5.0.9
COPY ./albumcollection/albumcollection /app
COPY entrypoint.sh /app

WORKDIR /app

RUN ["dotnet", "add package JUnitTestLogger --version 1.1.0"]

RUN ["dotnet", "restore"]

RUN ["dotnet", "build"]

RUN ["dotnet", "test --logger junit;LogFilePath=./testresults.xml"]

EXPOSE 80/tcp

RUN chmod +x ./entrypoint.sh

CMD /bin/bash ./entrypoint.sh



