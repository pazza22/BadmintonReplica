# Badminton4All Portal

A comprehensive badminton community portal built with ASP.NET Core MVC. This application provides player management features including registration, profiles, rankings, and match statistics.

## Features

### Player Features
- **Player Registration**: Register new players with detailed profiles
- **Player Profiles**: View comprehensive player information including:
  - Personal details (name, email, phone)
  - Skill level (Beginner, Intermediate, Advanced, Expert, Professional)
  - Overall ranking
  - Preferred courts
  - Match history and statistics
  
- **Rankings System**: View player rankings with:
  - Overall ranking position
  - Total matches played
  - Win/Loss records
  - Win rate percentage
  - Special highlighting for top 3 players (gold, silver, bronze medals)

- **Match History**: Track performance with detailed match records including:
  - Match dates
  - Opponents
  - Scores
  - Match types (Singles, Doubles, Mixed Doubles)
  - Court locations
  - Win/Loss results

- **Statistics Dashboard**: Automatic calculation of:
  - Total matches
  - Wins and losses
  - Win rate percentage
  - Player ranking

### Technical Features
- **Mock Data Service**: In-memory data storage (no database required)
- **Pre-populated Data**: Includes 5 sample players with complete match histories
- **Responsive Design**: Bootstrap 5 for mobile-friendly interface
- **Modern UI**: Font Awesome icons and custom styling

## Project Structure

```
badminton4all/
├── Controllers/
│   ├── HomeController.cs          # Home page controller
│   └── PlayerController.cs        # Player management controller
├── Models/
│   ├── ErrorViewModel.cs          # Error handling model
│   └── Player.cs                  # Player and match models
├── Services/
│   └── MockPlayerService.cs       # In-memory data service
├── Views/
│   ├── Home/
│   │   └── Index.cshtml           # Landing page
│   ├── Player/
│   │   ├── Index.cshtml           # Players list
│   │   ├── Details.cshtml         # Player profile
│   │   ├── Register.cshtml        # Registration form
│   │   ├── Edit.cshtml            # Edit profile
│   │   ├── Delete.cshtml          # Delete confirmation
│   │   └── Rankings.cshtml        # Rankings leaderboard
│   └── Shared/
│       └── _Layout.cshtml         # Main layout with navigation
└── wwwroot/
    └── css/
        └── site.css               # Custom styles
```

## How to Run

1. **Prerequisites**:
   - .NET 10.0 SDK or later

2. **Build the project**:
   ```bash
   dotnet build
   ```

3. **Run the application**:
   ```bash
   dotnet run
   ```

4. **Access the application**:
   - Open your browser and navigate to the URL displayed in the terminal
   - Typically: `https://localhost:5001` or `http://localhost:5000`

## Using the Portal

### Home Page
- Landing page with call-to-action buttons
- Quick access to main features
- Overview of portal capabilities

### Browse Players
- Navigate to "Players" in the menu
- View all registered players in card format
- See quick stats for each player
- Click "View Profile" for detailed information

### View Rankings
- Navigate to "Rankings" in the menu
- See all players sorted by ranking
- View detailed statistics in table format
- Top 3 players highlighted with medals

### Register a New Player
- Navigate to "Register" in the menu
- Fill out the registration form:
  - Full name (required)
  - Email (required)
  - Phone number (optional)
  - Skill level (required)
  - Profile picture URL (optional)
  - Preferred courts (multiple selection)
- Submit to create your profile

### Edit Profile
- Go to a player's profile page
- Click "Edit Profile"
- Update information as needed
- Save changes

### View Player Statistics
- Click on any player to view their profile
- See comprehensive statistics:
  - Overall ranking
  - Total matches, wins, losses
  - Win rate
  - Match history with all details
  - Preferred courts

## Mock Data

The application includes pre-populated data for 5 players:
1. **John Chen** - Advanced, Rank #1
2. **Sarah Lee** - Advanced, Rank #2
3. **Emma Davis** - Expert, Rank #3
4. **Mike Wong** - Intermediate, Rank #5
5. **David Kim** - Beginner, Rank #12

Each player has a complete profile with match history and statistics.

## Available Courts

The system includes 6 pre-configured courts:
- Central Sports Complex
- Riverside Badminton Club
- Elite Sports Arena
- Westside Community Center
- North Point Sports Hub
- Metro Badminton Academy

## Customization

### Adding More Courts
Edit `MockPlayerService.cs` and add courts to the `_availableCourts` list.

### Modifying Skill Levels
Edit the `SkillLevel` enum in `Models/Player.cs`.

### Styling Changes
Customize the appearance by editing `wwwroot/css/site.css`.

## Notes

- This is a demonstration application using in-memory mock data
- Data is reset when the application restarts
- No database configuration required
- Perfect for learning, demos, or proof-of-concept

## Technologies Used

- ASP.NET Core MVC (.NET 10.0)
- Bootstrap 5
- Font Awesome 6
- C# 12
- Razor Views
- Dependency Injection

## Future Enhancements

Potential features to add:
- Match scheduling system
- Tournament management
- Player messaging
- Court booking system
- Achievement badges
- Social features (friends, challenges)
- Data persistence with a database

---

**Badminton4All** - Your Ultimate Badminton Community Portal
