#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["insta3core3/insta3core3.csproj", "insta3core3/"]
RUN dotnet restore "insta3core3/insta3core3.csproj"
COPY . .
WORKDIR "/src/insta3core3"
RUN dotnet build "insta3core3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "insta3core3.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "insta3core3.dll"]