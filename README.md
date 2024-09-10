# THIS IS A FAKE IP TOOL FOR ANDROID PHONES USING PROXY
# Step 1: Download and Install Android SDK Platform Tools
### Download SDK Platform Tools:
[Android SDK Platform Tools download page.](https://developer.android.com/tools/releases/platform-tools)

# Step 2: Add ADB to the PATH

## On Windows:

### Open Control Panel:
- Press **Win + R**, type **control panel**, and press **Enter**.

### Go to System and Security:
  - Select **System and Security**, then select **System**.
  
### Choose Advanced System Settings:
  - On the left side, select **Advanced system settings**.
  
### Open Environment Variables:
- In the **System Properties** window, select the **Environment Variables** button.

### Edit the PATH Variable:
- In the **System variables** section, scroll down and find the **Path** variable, then select **Edit**.

### Add the ADB Path:
- In the **Edit Environment Variable** window, select **New** and add the path to the folder containing **adb.exe**. For example, add **C:\adb\platform-tools**.

### Save and Exit:
- Click **OK** to save the changes and close all windows.

## On macOS and Linux:

### Open Terminal.

### Edit the Shell Configuration File:
- For **bash**, edit the **~/.bashrc** or **~/.bash_profile** file.
- For **zsh**, edit the **~/.zshrc** file.

### Add the ADB Path:
- Add the following line to the end of the file:
```
export PATH=$PATH:/path/to/adb/platform-tools
```
- Replace **/path/to/adb/platform-tools** with the actual path to the folder containing **adb**.

### Save and Reload the Configuration:
- Save the file and run the following command to reload the configuration:
```
source ~/.bashrc  # or ~/.zshrc depending on your shell
```
# Step 3: Fake Ip
- Install
```
git clone https://github.com/doanvtamhuynh/fakeipwithproxy.git
```
- Connect to device using USB
- Enter your Proxy in **Your Proxy** and click **Fake IP**
- Press **Stop Fake** to close
