# VEGG.TABLE
A peer-to-peer marketplace for local produce and surplus food to promote sustainable community sharing.

Our whiteboard: [Figma Board](https://www.figma.com/board/jRS3cdT5qpY0piIOLnXisa/VEGG.TABLE?node-id=0-1&p=f&t=Jq6VlaDEQLm4XsCp-0)

---

## 🏗️ Project Overview & Architecture

VEGG.TABLE is built using **Clean Architecture**. This design philosophy separates the application into distinct layers, ensuring that our domain logic, infrastructure (data access), and the user interface (Blazor) remain decoupled and maintainable.



### Visual Folder Structure

```text
/VEGG.TABLE
├── .github/
│   └── workflows/
│       └── build-and-test.yml        # CI/CD pipeline to automate testing and build verification
├── .husky/
│   ├── commit-msg                    # Hook to validate commit message standards
│   ├── pre-commit                    # Hook to run tests before code is committed
│   ├── task-runner.json              # Configures task execution for husky hooks
│   └── validate-commit-msg.ps1       # Script to check commit message format
├── src/
│   ├── VEGG.TABLE.API/
│   │   ├── Controllers/
│   │   │   ├── ProduceController.cs  # Manages HTTP requests related to produce
│   │   │   └── UserController.cs     # Manages user authentication and profile requests
│   │   ├── Properties/
│   │   │   ├── launchSettings.json   # Defines environment variables and launch profiles
│   │   │   ├── appsettings.Development.json # Development-specific configuration
│   │   │   └── appsettings.json      # Global configuration settings
│   │   ├── GlobalUsings.cs           # Centralized namespace imports for the API project
│   │   ├── Program.cs                # Entry point: configures services, CORS, and middleware
│   │   ├── VEGG.TABLE.API.csproj     # Project definition and dependency list
│   │   └── VEGG.TABLE.API.http       # HTTP request file for testing API endpoints
│   ├── VEGG.TABLE.Client/
│   │   ├── Components/
│   │   │   ├── ProduceCard.razor     # UI component displaying specific produce items
│   │   │   └── ThemeToggle.razor     # Logic/UI for switching light/dark modes
│   │   ├── Layout/
│   │   │   ├── Footer.razor          # Global footer structure
│   │   │   ├── MainLayout.razor      # Base layout template for the application
│   │   │   ├── MainLayout.razor.css  # Styles applied to the main layout
│   │   │   └── Navbar.razor          # Main navigation bar component
│   │   ├── Pages/
│   │   │   ├── About.razor           # Static about page
│   │   │   ├── Home.razor            # Main dashboard showing market produce
│   │   │   ├── Login.razor           # User sign-in page
│   │   │   ├── NotFound.razor        # Error page for invalid routes
│   │   │   ├── Profile.razor         # Dynamic dashboard that renders role-specific views (Seller or Buyer)
│   │   │   └── Register.razor        # User registration form
│   │   ├── wwwroot/
│   │   │   ├── css/
│   │   │   │   ├── app.css           # Final compiled CSS for the browser (Tailwind CSS generates this on each run)
│   │   │   │   └── input.css         # Tailwind source file with directives (Colour themes for light/dark modes etc..)
│   │   │   └── index.html            # Main HTML entry point for the WebAssembly app
│   │   ├── App.razor                 # Root router component for navigation
│   │   ├── GlobalUsings.cs           # Centralized namespace imports for the Client project
│   │   ├── package-lock.json         # NPM dependency lock file
│   │   ├── package.json              # Defines NPM dependencies for Tailwind/Build tools
│   │   ├── Program.cs                # Client-side configuration and dependency injection
│   │   ├── VEGG.TABLE.Client.csproj  # Client project file
│   │   └── _Imports.razor            # Global razor imports for components
│   ├── VEGG.TABLE.Core/
│   │   ├── Entities/
│   │   │   ├── Produce.cs            # Data model representing a produce item
│   │   │   ├── User.cs               # Data model representing a user
│   │   │   ├── UserProduceLike.cs    # Represents user interaction (likes)
│   │   │   └── UserProduceTransaction.cs # Transaction log for produce sales
│   │   ├── Interfaces/
│   │   │   ├── IProduceRepository.cs # Defines data access methods for produce
│   │   │   ├── IProduceService.cs    # Business logic contract for produce
│   │   │   ├── IUserRepository.cs    # Defines data access methods for users
│   │   │   └── IUserService.cs       # Business logic contract for users
│   │   ├── GlobalUsings.cs           # Centralized imports
│   │   └── VEGG.TABLE.Core.csproj    # Project file
│   └── VEGG.TABLE.Infrastructure/
│       ├── Data/
│       │   └── DBContext.cs          # EF Core context for database interactions
│       ├── Migrations/               # Database schema versioning
│       ├── Services/
│       │   ├── ProduceService.cs     # Implementation of produce business logic
│       │   └── UserService.cs        # Implementation of user business logic
│       ├── GlobalUsings.cs           # Centralized imports
│       ├── ProduceRepository.cs      # Database access logic for produce
│       ├── UserRepository.cs         # Database access logic for users
│       └── VEGG.TABLE.Infrastructure.csproj # Project file
├── tests/
│   └── VEGG.TABLE.UnitTests/
│       ├── Domain/
│       │   └── EntityNameTests.cs    # Tests for core domain logic
│       ├── Repositories/
│       │   └── ProduceRepositoryTests.cs # Tests for data access layer
│       ├── Services/
│       │   ├── ProduceServiceTests.cs    # Tests for produce business logic
│       │   └── UserServiceTests.cs       # Tests for user-related business logic
│       ├── GlobalUsings.cs           # Centralized imports for tests
│       ├── Utils.cs                  # Helper methods for unit tests
│       └── VEGG.TABLE.UnitTests.csproj # Test project definition
├── .editorconfig                     # Code style enforcement rules
├── .gitattributes                    # Git file handling configurations
├── .gitignore                        # Files excluded from source control
├── Directory.Build.props             # Global build configuration for all projects
├── Directory.Packages.props          # Centralized NuGet versioning
├── docker-compose.yml                # Infrastructure orchestration (e.g., DB)
├── LICENSE                           # Project license
├── README.md                         # Main project documentation
└── VEGG.TABLE.sln                    # Visual Studio solution file
```

---

# 🎨 Frontend Deep Dive (VEGG.TABLE.Client)

The frontend is a **Blazor WebAssembly** application, enabling C# to execute within the browser. We leverage **Tailwind CSS** as a utility-first framework; for instance, applying `bg-emerald-800` directly to an HTML element instantly sets its background color without needing a separate CSS file.

## 🎨 Understanding Tailwind CSS: Our "Box of Bricks"

Think of Tailwind CSS as a giant, organized box of Lego bricks. Instead of building your own furniture from scratch—which is what you do when you write custom CSS files—you simply reach into the box and grab exactly the "bricks" (utility classes) you need to build your website's layout and style.

### Why do we use it?
1. **Consistency:** You don't have to guess how many pixels of margin to add. Tailwind provides standard "bricks" that ensure your website's spacing and colors are always uniform.
2. **Speed:** You can style elements directly inside your HTML (or Razor) files without ever switching to a separate CSS file.
3. **Responsiveness:** Tailwind makes it incredibly easy to change your design for different screen sizes (like mobile vs. desktop) using simple prefixes.

---

### The "Lego Bricks" Explained (Common Classes)

These are the most frequently used classes in our project. Each one does exactly one thing, which makes them very easy to combine.

| Class | What it does (The "Child's Play" Explanation) |
| :--- | :--- |
| `flex` | Turns an element into a "magic line tray." It automatically lines up its children in a straight row or column. |
| `grid` | Turns an element into "graph paper." It lets you define specific rows and columns for items to sit in. |
| `w-full` | Stretches an item so it takes up 100% of the width of its container. |
| `h-screen` | Makes an item exactly as tall as your browser window. |
| `p-4` | Adds "cushioning" (padding) *inside* the box, so the content isn't touching the edges. |
| `m-2` | Adds "personal space" (margin) *outside* the box, pushing other items away. |
| `gap-4` | Adds a specific amount of space between items inside a flex or grid box. |
| `rounded` | Smooths out sharp, pointy corners of a box into soft, rounded ones. |
| `shadow-lg` | Adds a large, soft drop-shadow so the element looks like it is "popping" off the page. |
| `bg-slate-900` | Paints the background of the box a deep, dark slate color. |
| `text-white` | Changes the color of your text to white. |
| `items-center` | Aligns all items in a flex/grid box to sit perfectly in the middle vertically. |
| `justify-center` | Aligns all items in a flex/grid box to sit perfectly in the middle horizontally. |
| `hidden` | Makes an element completely invisible (Display: none). |
| `block` | Makes an element take up its own line (Display: block). |
| `md:flex` | A "Screen-Size Brick." It tells the element: "Behave normally on phones, but turn into a flexbox once the screen is 'medium' size (tablet/desktop)." |
| `relative` | Sets the positioning so that if you add something "absolute" inside it, it stays trapped inside this box. |
| `font-bold` | Makes the text thicker and heavier. |
| `cursor-pointer` | Changes your mouse arrow into a hand icon, so users know a button is clickable. |
| `z-10` | The "Layer Brick." It pushes an element forward so it sits on top of other things (like a menu over a page). |

---

### How to use them together
The power of Tailwind comes from stacking these bricks. For example, if you want a professional-looking button, you don't write CSS. You just write:
`class="bg-emerald-800 text-white p-4 rounded shadow-lg hover:bg-emerald-700"`

* **`bg-emerald-800`**: Sets the color.
* **`text-white`**: Makes text readable.
* **`p-4`**: Gives the button comfortable breathing room.
* **`rounded`**: Softens the corners.
* **`shadow-lg`**: Makes it look like a real button you can press.
* **`hover:bg-emerald-700`**: A "Time-Travel Brick"—it tells the button to change color only when the mouse is hovering over it.

By combining these, you create complex designs instantly, keeping your code clean and very easy for other developers to read and change later!
### Component-Level Logic (@code blocks)

#### 1. Components/ProduceCard.razor
This component displays individual produce items fetched from the API.
* **`[Parameter] public Produce Item`**: Receives a `Produce` entity from the parent page.
* **`GetProduceEmoji(string name)`**: A helper method in the `@code` block that uses C# switch expressions to return specific emojis based on the produce name, acting as a dynamic visual fallback.
* **`RequestToBuy(Produce item)`**: Uses the `NavigationManager` to trigger an `mailto:` URI, allowing users to initiate a purchase request via their email client.

```csharp
@code {
    [Parameter] public Produce Item { get; set; } = default!; 
    // This receives the produce object from the parent page
    
    private void RequestToBuy(Produce item) {
        // Uses NavigationManager to trigger the browser's email client
        Navigation.NavigateTo($"mailto:support@vegg.table?subject=...");
    }
}
```

*Explanation:* The `@code` block acts as the "brain." It defines the `Item` property (which receives data) and the `RequestToBuy` method which handles user interaction.

#### 2. Components/ThemeToggle.razor
Handles user-specific interface themes.
* **`OnAfterRenderAsync`**: This lifecycle method executes once the page component renders. It verifies `firstRender` to ensure it only initializes the theme from the browser's `localStorage` once, avoiding unnecessary overhead.
* **`ToggleTheme`**: An async method that flips the `isDark` state and calls a JavaScript function (`themeManager.toggleTheme`) to apply CSS theme changes globally.

```csharp
protected override async Task OnAfterRenderAsync(bool firstRender) {
    if (firstRender) {
        isDark = await JS.InvokeAsync<bool>("themeManager.initializeTheme");
        StateHasChanged(); // Tells Blazor to re-render because the state changed
    }
}
```

*Explanation:* `OnAfterRenderAsync` runs after the page has finished loading in the browser. We check if it is the `firstRender` to ensure we only load the theme setting once.

#### 3. Layout/Footer.razor
This component defines the persistent footer structure displayed across all pages. It ensures branding and navigation links remain consistent regardless of which page the user is viewing.

#### 4. Layout/MainLayout.razor
This acts as the master template for the application. It incorporates the `Navbar` and `Footer` components and provides a central `<article>` area where page content is injected via the `@Body` directive.

#### 5. Layout/Navbar.razor
This manages the primary navigation menu. It handles the rendering of links and often includes logic for responsive behavior, ensuring the navigation menu adapts seamlessly between mobile and desktop viewports.

#### 6. Pages/About.razor
This is a static content page. It provides information regarding the project’s mission, sustainability goals, and the team behind the marketplace.

#### 7. Pages/Login.razor
This page facilitates user authentication.
* **Logic**: It contains an edit form bound to an authentication model.
* **Interaction**: Upon submission, it sends credentials to the API to receive a JWT or authentication token, which is then stored for session management.

```csharp
@code {
    private LoginModel loginModel = new();

    private async Task HandleLogin() {
        // Sends loginModel to Auth Service and manages local storage
    }
}
```

#### 8. Pages/NotFound.razor
A fallback page rendered when a user attempts to navigate to a route that does not exist. It improves user experience by providing a clear indication of an error and offering a link to return to the `Home` page.

#### 9. Pages/Profile.razor (to be created)
This page acts as a dynamic dashboard that adapts its view based on the authenticated user's role. It centralizes user-specific actions and history, ensuring a clean and intuitive user experience.

* **Logic**: Upon initialization, it retrieves the user's session data and identifies their role (Seller vs. Buyer).
* **Role-Based Rendering**:
    * **Seller Dashboard**: Provides interface elements to manage existing inventory and a mechanism to add new produce listings.
    * **Buyer History**: Displays a record of previous purchases and interactions within the marketplace.
* **Component Composition**: It orchestrates the rendering of sub-components (`SellerDashboard.razor` or `BuyerHistory.razor`) based on the authenticated role, keeping the `Profile.razor` code clean and modular.

```csharp
@page "/profile"
@using VEGG.TABLE.Client.Components

@if (isSeller)
{
    <SellerDashboard />
}
else
{
    <BuyerHistory />
}

@code {
    private bool isSeller;

    protected override async Task OnInitializedAsync() {
        // Logic to verify user identity and set isSeller flag
    }
}
```

#### 10. Pages/Register.razor
This page collects user details for new account creation.
* **Logic**: It implements validation logic to ensure passwords meet complexity requirements and email addresses are formatted correctly.
* **Interaction**: It coordinates with the `UserService` to persist the new user data to the database via the API.

#### 11. Pages/Home.razor

```csharp
protected override async Task OnInitializedAsync() {
    produceList = await Http.GetFromJsonAsync<List<Produce>>("api/produce");
}
```

*Explanation:* `OnInitializedAsync` is the lifecycle method that executes when the page is first accessed. It makes an asynchronous HTTP GET request to our API to fetch the current produce inventory.

### Page-Level Logic
* **`Home.razor`**: Uses `OnInitializedAsync`—a standard Blazor lifecycle method—to asynchronously call the API via `HttpClient` (e.g., `Http.GetFromJsonAsync<List<Produce>>("api/produce")`) to populate the page upon loading.
* **`Login.razor` / `Register.razor`**: These pages contain forms where the `@code` block defines the properties bound to input fields, preparing data for authentication requests.

---

## ⚙️ Configuration & Infrastructure

### Why the root files exist:
* **Directory.Build.props & Directory.Packages.props**: These ensure consistency across the solution. Centralizing dependencies here means that when we update a library version, it applies globally, preventing version conflicts between sub-projects.

### The API `Program.cs` & CORS
* **CORS in .API/Program.cs**: Because the Blazor client (`localhost:5209`) and the API (`localhost:5167`) run on different ports, the browser interprets them as different origins and restricts data flow. By adding the following, we define a policy allowing our Client to interact with the API:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient", policy =>
    {
        policy.WithOrigins("http://localhost:5209") 
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
app.UseCors("AllowClient");
```

---

## 🚀 Running the Project

Please follow these steps in order to ensure all services are correctly initialized:
0. **Setup**: Open 4 terminals and ensure Docker Desktop is running.
1. **Terminal 1 (Database)**: Open your terminal at the root and run `docker-compose up -d`. This starts the SQL Server container, ensuring the database is active (Docker Desktop must be running).
2. **Terminal 2 (API)**: Navigate to `src/VEGG.TABLE.API/` and run `dotnet run`. This hosts your data service on port 5167.
3. **Terminal 3 (Tailwind)**: Navigate to `src/VEGG.TABLE.Client/` and run `npm run dev`. This monitors your CSS and recompiles Tailwind styles in real-time.
4. **Terminal 4 (Blazor Frontend)**: In the same `Client` directory, run `dotnet watch`. This hosts the Blazor application, enabling live-reloading as you modify your code.