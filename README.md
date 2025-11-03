# ⚡ File Binder - Modern Edition ⚡

<div align="center">

![Status](https://img.shields.io/badge/Status-Active-success?style=for-the-badge)
![Version](https://img.shields.io/badge/Version-2.0-blue?style=for-the-badge)
![.NET](https://img.shields.io/badge/.NET-Framework%202.0-purple?style=for-the-badge)
![License](https://img.shields.io/badge/License-Educational-orange?style=for-the-badge)

**A powerful Windows application to bind multiple files into a single executable**

*Cracked by unknown hart* 🎯

</div>

---

## 🌟 New Features & Improvements

This modernized version includes stunning visual upgrades while maintaining 100% of the original functionality:

### ✨ Visual Enhancements

- **🎬 Cinematic Splash Screen**
  - Beautiful fade-in/fade-out animations
  - 2.5 minute display time for that dramatic entrance
  - Gradient background with glowing border effects
  - Professional "Cracked by unknown hart" branding

- **🎨 Modern UI Design**
  - Sleek gradient backgrounds with multi-color blends
  - Dark theme with cyan/green accent colors
  - Flat, modern button designs with custom borders
  - Professional Segoe UI typography

- **🖼️ UH 2006 Logo Overlay**
  - Semi-transparent background emblem
  - Crossed swords, wings, and laurel wreath design
  - Subtle 15% opacity for professional look
  - Customizable positioning

- **✨ Smooth Animations**
  - Form fade-in effect on load
  - Button hover animations (size increase)
  - Smooth transitions throughout
  - Professional touch and feel

### 🚀 New Functionality

- **💾 Save Location Chooser**
  - No more fixed output location
  - Choose where to save your binded file
  - Default filename: `binded.exe`
  - Full path control

- **📝 Enhanced User Feedback**
  - Better error messages
  - Success notifications with file path
  - Warning dialogs for empty operations
  - Professional message boxes

### 🎯 Color-Coded Buttons

- **➕ Add Files** - Blue border (`#6496FF`)
- **❌ Remove** - Red border (`#FF6464`)
- **🎨 Edit Icon** - Orange border (`#FFC864`)
- **🔗 BIND FILES** - Green border (`#64FF64`)

---

## 📋 Features

### Core Functionality
- ✅ Bind multiple files into a single executable
- ✅ Custom icon support (.ico files)
- ✅ Automatic file extraction on execution
- ✅ Resource embedding and compilation
- ✅ Silent execution (no console window)
- ✅ Multi-file selection support

### Technical Features
- 🔧 C# CodeDOM compilation
- 🔧 Resource Hacker integration for icon replacement
- 🔧 .NET Framework 2.0 compatible
- 🔧 Windows Forms application
- 🔧 Embedded resource management

---

## 🖥️ System Requirements

- **OS**: Windows 7/8/10/11
- **Framework**: .NET Framework 2.0 or higher
- **RAM**: 512 MB minimum
- **Disk Space**: 5 MB

---

## 📦 Installation

### Option 1: Download Release
1. Download the latest release from the releases page
2. Extract the ZIP file
3. Run `File Binder.exe`

### Option 2: Build from Source

#### Prerequisites
- Visual Studio 2019 or later
- .NET Desktop Development workload

#### Build Steps
```bash
# Clone the repository
git clone https://github.com/yourusername/File-Binder.git

# Open in Visual Studio
cd File-Binder
start File-Binder.sln

# Build in Visual Studio
# Press F6 or Build > Build Solution
# Set configuration to "Release"

# Output location
# bin\Release\net20\
```

---

## 🎨 Adding the UH 2006 Logo

To display the beautiful UH 2006 background logo:

### Quick Setup (30 seconds)

1. **Save your logo image** as `uh2006.png`
2. **Place it** in the same folder as `File Binder.exe`
3. **Run the application** - Logo appears automatically!

### File Structure
```
📁 Your Folder
   ├── File Binder.exe
   ├── uh2006.png          ← Place logo here
   └── (other files...)
```

### Customizing Logo Opacity

Edit `FileBinderForm.cs` line 241 to adjust visibility:

```csharp
colorMatrix.Matrix33 = 0.15f; // 0.0 = invisible, 1.0 = fully visible
```

**Recommended values:**
- `0.10` - Very subtle (ghost effect)
- `0.15` - Default (perfect balance) ✓
- `0.25` - More prominent
- `0.50` - Half visible

---

## 🎯 How to Use

### Step 1: Add Files
1. Click **➕ Add Files** button
2. Select one or multiple files to bind
3. Files appear in the list box

### Step 2: Edit Icon (Optional)
1. Click **🎨 Edit Icon** button
2. Select an `.ico` file
3. Icon will be applied to the final executable

### Step 3: Bind Files
1. Click **🔗 BIND FILES** button
2. Choose where to save the output file
3. Enter a filename (default: `binded.exe`)
4. Wait for compilation
5. Success! Your files are now binded

### Step 4: Run Binded File
- Double-click the generated `.exe`
- All embedded files are automatically extracted
- Files are written to the same directory

---

## 🎨 UI Customization

### Changing Splash Screen Duration

Edit `SplashScreen.cs` line 28:

```csharp
displayTimer.Interval = 150000; // Time in milliseconds (150000 = 2.5 minutes)
```

### Adjusting Animation Speed

Edit `SplashScreen.cs` line 23:

```csharp
fadeTimer.Interval = 30; // Lower = faster fade (20-50 recommended)
```

Edit line 111:

```csharp
opacity += 0.03; // Higher = faster fade (0.02-0.05 recommended)
```

### Changing Color Scheme

Edit `FileBinderForm.cs` in the `InitializeComponent()` method:

```csharp
// Background colors
this.BackColor = Color.FromArgb(20, 20, 30); // Main dark background

// ListBox colors
this.fileListBox.BackColor = Color.FromArgb(30, 30, 40); // Darker panel
this.fileListBox.ForeColor = Color.FromArgb(0, 255, 150); // Cyan text

// Button colors - customize each button
this.addButton.BackColor = Color.FromArgb(60, 60, 80);
this.addButton.FlatAppearance.BorderColor = Color.FromArgb(100, 150, 255);
```

---

## 📸 Screenshots

### Splash Screen
- Cinematic 2.5-minute intro
- "Cracked by unknown hart" branding
- Beautiful gradient background
- Smooth fade animations

### Main Interface
- Modern dark theme
- Color-coded buttons
- Semi-transparent UH 2006 logo
- Cyan file list display
- Professional layout

---

## ⚠️ Important Notes

### Educational Purpose
This tool is for **educational purposes only**. Always respect software licenses and intellectual property rights.

### Antivirus Detection
File binders may be flagged by antivirus software as potentially unwanted programs (PUP). This is normal behavior for file binding applications. Add exceptions if needed.

### Use Cases
- Software deployment
- File packaging
- Installer creation
- Resource bundling
- Educational projects

---

## 🔧 Technical Details

### Architecture
```
File Binder
├── SplashScreen.cs          → Animated intro screen
├── FileBinderForm.cs        → Main application UI
├── Program.cs               → Application entry point
└── Properties/
    └── Resources.resx       → Embedded resources
```

### Compilation Process
1. User selects files to bind
2. Files are embedded as resources
3. Stub code is generated (dropcode)
4. C# CodeDOM compiles the final executable
5. Optional: Icon is replaced using Resource Hacker
6. Output file is saved to user-selected location

### Embedded Resources
- `Dropcode` - Template for file extraction
- `CompileCode` - Main executable template
- `ResHacker.exe` - Icon replacement tool

---

## 🐛 Troubleshooting

### Logo Not Showing?
- ✅ Verify filename is exactly `uh2006.png` (lowercase)
- ✅ Check the image is in the same folder as the EXE
- ✅ Try PNG format instead of JPG
- ✅ Ensure the image is not corrupted

### Compilation Errors?
- ✅ Install .NET Framework 2.0 or higher
- ✅ Run as Administrator if permission errors occur
- ✅ Check antivirus isn't blocking compilation
- ✅ Ensure sufficient disk space

### Splash Screen Too Long/Short?
- Edit `SplashScreen.cs` line 28
- Change `displayTimer.Interval` value
- 1000 = 1 second, 150000 = 2.5 minutes

### Buttons Not Responding?
- ✅ Ensure all files are in the same directory
- ✅ Check .NET Framework is installed
- ✅ Try rebuilding the project

---

## 🎨 Color Reference

### Main UI Colors
| Element | Color Code | RGB | Description |
|---------|------------|-----|-------------|
| Background | `#14141E` | (20, 20, 30) | Dark navy |
| ListBox BG | `#1E1E28` | (30, 30, 40) | Darker panel |
| ListBox Text | `#00FF96` | (0, 255, 150) | Cyan green |
| Button BG | `#3C3C50` | (60, 60, 80) | Gray purple |
| Add Border | `#6496FF` | (100, 150, 255) | Blue |
| Remove Border | `#FF6464` | (255, 100, 100) | Red |
| Icon Border | `#FFC864` | (255, 200, 100) | Orange |
| Bind Border | `#64FF64` | (100, 255, 100) | Green |

---

## 📄 License

This project is released for **educational purposes**. 

```
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED. USE AT YOUR OWN RISK.
```

---

## 👨‍💻 Credits

**Original Concept**: File Binder  @wireless90
**Modernization**: 2024  
**Cracked/moded by**: unknown hart  

### Special Thanks
- 
- Resource Hacker developers
- Open source community

---

## 🌐 Connect

- 🐛 Report bugs in the Issues section
- 💡 Suggest features via Pull Requests
- ⭐ Star this repo if you like it!
- 🔄 Fork and customize for your needs

---

<div align="center">

### 🔥 Made with passion and modern design principles 🔥

**Cracked by unknown hart** • 2006-2024

![Footer](https://img.shields.io/badge/Built%20With-C%23-blueviolet?style=for-the-badge&logo=c-sharp)
![Footer](https://img.shields.io/badge/UI-Windows%20Forms-blue?style=for-the-badge&logo=windows)
![Footer](https://img.shields.io/badge/Design-Modern-success?style=for-the-badge&logo=aesthetics)

---

⚡ **Bind files in style** ⚡

</div>

 # File-Binder words of original creator and  moder/cracker unknone hart 

Helps bind files together into a single executable, usually used by hacker @ security reasurchers .


credit https://github.com/wireless90/File-Binder original creator

# Demo

![Demo](https://secretsofthesolstice.files.wordpress.com/2015/08/file_binder.gif)

# note 
# if u are using my mode dont forget to giev me credits 
