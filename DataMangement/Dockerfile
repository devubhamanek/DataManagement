#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-sac2016 AS base
WORKDIR /app
EXPOSE 51863
EXPOSE 44303

FROM microsoft/dotnet:2.1-sdk-nanoserver-sac2016 AS build
WORKDIR /src
COPY ["DataMangement/DataMangement.csproj", "DataMangement/"]
RUN dotnet restore "DataMangement/DataMangement.csproj"
COPY . .
WORKDIR "/src/DataMangement"
RUN dotnet build "DataMangement.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DataMangement.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DataMangement.dll"]