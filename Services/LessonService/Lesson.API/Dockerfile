#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicroServices/LessonService/Lesson.API/Lesson.API.csproj", "MicroServices/LessonService/Lesson.API/"]
RUN dotnet restore "MicroServices/LessonService/Lesson.API/Lesson.API.csproj"
COPY . .
WORKDIR "/src/MicroServices/LessonService/Lesson.API"
RUN dotnet build "Lesson.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lesson.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lesson.API.dll"]