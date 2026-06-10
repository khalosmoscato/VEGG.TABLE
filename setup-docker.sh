# Make sure to run this script with `source setup-docker.sh` to ensure environment variables are set in the current shell session.
# Add execution permision using: 
# chmod +x setup-docker.sh 

#!/bin/bash

# 1. Ensure the directory exists
CERT_DIR="$HOME/.aspnet/https"
mkdir -p "$CERT_DIR"

# 2. Export the certificate if it doesn't already exist
CERT_PATH="$CERT_DIR/aspnetapp.pfx"
if [ ! -f "$CERT_PATH" ]; then
    echo "Exporting new dev certificate..."
    dotnet dev-certs https -ep "$CERT_PATH" -p yourpassword123 --trust
else
    echo "Certificate already exists at $CERT_PATH."
fi

# 3. Export the environment variable for the current session
# Note: This variable will only last for the duration of this terminal session.
export SSL_PATH="$CERT_DIR"
echo "SSL_PATH set to: $SSL_PATH"

# 4. Run Docker commands
echo "Cleaning up existing containers..."
docker compose down

echo "Starting services..."
docker compose up --build -d

echo "Done! Services should be starting up."