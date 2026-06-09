# Detect Operating System
ifeq ($(OS),Windows_NT)
    # Windows
    SETUP_CMD = powershell -ExecutionPolicy Bypass -File setup-docker.ps1
else
    # macOS/Linux: Add a step to ensure permissions are correct
    SETUP_CMD = chmod +x setup-docker.sh && ./setup-docker.sh
endif

# Default command: run the setup
setup:
	@$(SETUP_CMD)
up:
	docker compose up -d

# Helper to clean up
down:
	docker compose down