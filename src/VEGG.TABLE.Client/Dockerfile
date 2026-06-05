# Stage 1: Tailwind - build CSS
FROM node:20 AS tailwind
WORKDIR /app
COPY src/VEGG.TABLE.Client/package*.json ./
RUN npm install
COPY src/VEGG.TABLE.Client/ ./
RUN npm run build
# Output: /app/wwwroot/css/app.css

# Stage 2: Blazor - publish WASM
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS blazor
WORKDIR /src
COPY Directory.Build.props .
COPY Directory.Packages.props .
COPY VEGG.TABLE.slnx .
COPY src/VEGG.TABLE.Client/*.csproj src/VEGG.TABLE.Client/
COPY src/VEGG.TABLE.Core/*.csproj src/VEGG.TABLE.Core/
RUN dotnet restore src/VEGG.TABLE.Client/VEGG.TABLE.Client.csproj
COPY src/ src/
COPY --from=tailwind /app/wwwroot/css/app.css src/VEGG.TABLE.Client/wwwroot/css/app.css
RUN dotnet publish src/VEGG.TABLE.Client/VEGG.TABLE.Client.csproj -c Release -o /publish

# Stage 3: nginx - serve static files
FROM nginx:alpine
COPY --from=blazor /publish/wwwroot /usr/share/nginx/html
EXPOSE 80
