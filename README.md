# Toast notifcations for .NET 6+ Windows apps

This library provides a flexible to asynchronous toast notifcations in .NET Windows apps. Figure 1 below shows an example of one of the toast options.

![collateral/toast-example.gif](https://rogerpence.dev/collateral/toast-example.gif)

<small>Figure 1. An example toast notification.</small>

This repo includes two projects:

1. **ToastNotfication** - this is a Windows form app to test the ToastNotificationLibrary.

2. **ToastNotificationLibrary** - a small class library that provides the toast notifier form.

I struggled for a long time trying to the get the toast form fade-in/fade-out working. I finally found [Nate Fiscaletti's gist](https://gist.github.com/nathan-fiscaletti/3c0514862fe88b5664b10444e1098778) with a C# class that fades Windows forms in and out. It provides exactly what I needed to do. I used an unmodified version of Nate's code. Thank you, Nate! 

### Example code to show a toast

These two examples provide a quick glance at how to display a toast. 

This is the minimal code needed to show a toast in the lower left-hand corner of the parent form:

```c#
Toast toast  = new Toast(this);
toast.HeaderText = "Congratulations";
toast.MessageText = "Yay! World's best cup of coffee!";
toast.ShowToast();
```

This code shows a toast in the center of the parent form with error color and icon and for an extra long duration: 

```c#
Toast toast  = new Toast(this);
toast.HeaderText = "An error occurred";
toast.MessageText = "An error with your database occurred";
toast.Status = ToastStatus.ERROR;
toast.Position = ToastPosition.CENTER;
toast.Duration = ToastDuration.EXTRA_LONG;
toast.ShowToast();
```

## Toast members

### Toast constructor

```c#
Toast(Form parentForm)
```

Pass a reference to toast's parent form in the toast's constructor (usually with this). This makes the parent form's location to the toast so it can position itself relative to its parent form.

```c#
Toast(Form parentForm)
```

```c#
Toast toast  = new Toast(this);
```

### Toast methods

#### `ShowToast()`

Show a toast

#### `CloseToast()`

`CloseToast()` method is used to close the toast programmatically--usually when you're displaying show-progress type toasts with a long-running process. 

#### `ChangeDefaultDurationInSections(int, int, int, int)`

Change the default seconds a toast is displayed (these values relate to the values represented by the `ToastDuration` enumeration discussed later). There is more on this method below.

#### `SetMessageText(string)`

Set a toast's message text. The `MessageText` property should be set before you display a toast. The `SetMessageText` method is for changing a toast's message text while the toast is displayed (for example, changing the text displayed during the program of a long-running process).

## Toast properties

### Toast properties overview

| Property            | Description            | Type   | Default                  |
|:------------------- | :---------------------- | :------ | :------------------------ |
| BackgroundColor     | Background color       | Color  | #F5F5F5                  |
| BorderColor         | Border color           | Color  | #D3D3D3                  |
| Duration            | Seconds shown          | enum   | ToastDuration.SHORT      |
| HeaderText          | Header text            | string | none                     |
| HideAccentAndIcon   | Hide accent/icon       | bool   | false                    |
| HideHeaderMessage   | Hide header text       | bool   | false                    |
| HideUserCloseButton | Hide user close button | bool   | false                    |
| MessageText         | Message text           | string | none                     |
| Position            | Toast position         | enum   | ToastPosition.LOWER_LEFT |
| Status              | Toast status           | enum   | ToastStatus.SUCCESS      |

#### BackgroundColor

| Description            | Type                 | Default |
| :---------------------- | :-------------------- | :------- |
| Toast background color | System.Drawing.Color | #F5F5F4 |

#### BorderColor

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| Toast border color | System.Drawing.Color | #D3D3D3 |

#### Duration

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| Seconds that a toast is displayed | ToastDuration enum | ToastDuration.SHORT |

| Enum value               | Default seconds toast is displayed           |
| :------------------------ | :-------------------------------------------- |
| ToastDuration.SHORT      | 3                                            |
| ToastDuration.MEDIUM     | 6                                            |
| ToastDuration.LONG       | 9                                            |
| ToastDuration.EXTRA_LONG | 12                                           |
| ToastDuration.FOREVER    | Toast displays until it is explicitly closed |

The default durations can be changed by calling the ChangeDefaultDurationSeconds() method after instancing a Toast and before displaying it:

```c#
ChangeDefaultDurationSeconds(int slowDuration,
                             int mediumDuration,
                             int longDuration,
                             int extraLongDuration)
```

If `Duration` is set to `ToastDuration.FOREVER` by default a close "x" icon is shown in the upper-right hand corner of the toast:

![collateral/user-close-toast.png](https://rogerpence.dev/collateral/user-close-toast.png)

There may be times when you want a long-lasting toast but don't want it closed by the user--rather you want to explicitly close it with your code. To do that, set `Dudration` to `ToastDuration.FOREVER` and set the `HideUserCloseButton` to `true`. When you want to close the toast, call the toast instance's `CloseToast()` method. This is discussed in more detail in the "Avoiding Windows UI threading conflicts" section below.

### HeaderText

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| Header text of a toast | string | none |

A toast's bold header text. Use the `HideHeaderMessage` property to hide this.

### HideAccentAndIcon

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| A Boolean that hides the vertical accent bar and icon | Bool | false |

### HideHeaderMessage

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| A Boolean that hides the toast header message | Boolean | false |

### HideUserCloseButton

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| A Boolean that hides the user-close "x" icon | Boolean | false |


### MessageText

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| Toast message | string | none |


### Position

| Description      | Type  | Default |
| :---------------- | :----- | :------ |
| The toast position relative to its parent form | ToastPosition | ToastPosition.LOWER_LEFT |

```
ToastPosition.TOP_LEFT

ToastPosition.TOP_RIGHT

ToastPosition.LOWER_LEFT

ToastPosition.LOWER_RIGHT

ToastPosition.CENTER
```

### Status

| Description      | Type  | Default |
| :---------------- | :----- | :------- |
| Controls the toast accent color and icon | ToastStatus | ToastStatus.Succes |

ToastStatus.SUCCESS - #408C3A with a checkbox 

![collateral/toast-success.png](https://rogerpence.dev/collateral/toast-success.png)

ToastStatus.INFO - #0F4CF1 with an exclamation point

![collateral/toast-info.png](https://rogerpence.dev/collateral/toast-info.png)

ToastStatus.ERROR - #FF1B00 with a bomb

![collateral/toast-error.png](https://rogerpence.dev/collateral/toast-error.png)

## Testing your toast

The ToastNotificatino project in this repo is a Winform program that lets you play around with a toast configuration. Set the properties as needed and click "Show toast" to see the toast. If the toast duration is set to "user close" (which resolves to ToastDuration.FOREVER), the "Close toast" button is enabled.

![collateral/toast-example.gif](https://rogerpence.dev/collateral/toast-example.gif)

```
Toast toast = new Toast(this);

toast.Position = Toast.ToastPosition.LOWER_LEFT;
toast.Duration = Toast.ToastDuration.SHORT;
toast.Status = Toast.ToastStatus.SUCCESS;

toast.HideUserCloseButton = false;
toast.HideHeaderMessage = false;
toast.HideAccentAndIcon = false;

toast.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
toast.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");

toast.HeaderText = "Congratulations!";
toast.MessageText = "Yay! You did it! World's greatest cup of coffee!";

// If you want to change the default duration values:
// toast.ChangeDefaultDurationSeconds(slowDuration: 5,
//                                    mediumDuration: 10
//                                    longDuration: 15,
//                                    extraLongDuration: 20)
toast.ShowToast();
```

In the unlikely event that you want to close a Toast from a button the toast's parent form, this code (usually placed just before the `ShowToast()` method) lets you assign a button's click event handler to the toast's `CloseToast()` method. Assigning the event hander with a lambda means you don't need to declare the toast globally.

```
EventHandler handler = null;
handler = (s, e) =>
{
    toast.CloseToast();
    [your-button-control].Click -= handler;
};
[your-button-control].Click += handler;
```

## Avoiding Windows UI threading conflicts

For simple notifications that fade away on their own you don't need to worry about toasts being disrupted by the Windows UI thread. However, you may want to use a toast to display progress during a long-running process. .NET's async [`Task.Run()`](https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.run?view=net-7.0) method enables this easily. 

In the example below, `StageReleaseSetProcesing()` is a top-level routine that kicks off the long running process, `StageReleaseSet()`. `StageReleaseSetProcessing()` first shows a toast (with its `Duration` set to  `ToastDuration.FOREVER` and its `HideUserCloseButton` set to `true`). The toast is initially displayed with the message "In progress..." 

A `Progress` class is instanced with a lambda that sets the toast message with its `value` argument. When invoked as a task the long-running `StageReleaseSet()`does its work and reports its progress through the `Progress` object's `Report()` method,

```
progress.Report(rs.binary_filename); 
```
which, through the lambda assignment, sets the toast message to the just-processed file name. When the work is done, the toast's `CloseToast()` method closes the toast.

```
public async void StageReleaseSetProcessing() 
{
    ShowStagingToast("In progress...");
    this.Cursor = Cursors.WaitCursor;

    var progress = new Progress<string>(value =>
    {
        toast.SetToastMessage(value);
    });
    
    DownloadStaging ds = new();
    await Task.Run(() => ds.StageReleaseSet(progress));
    this.Cursor = Cursors.Default;
    toast.CloseToast();
}

public Toast ShowStagingToast(string message)
{
    toast = new Toast(this);

    toast.Position = Toast.ToastPosition.CENTER;
    toast.Duration = Toast.ToastDuration.FOREVER;
    toast.Status = Toast.ToastStatus.INFO;
    toast.HideUserCloseButton = true;
    toast.HideHeaderMessage = false;
    toast.HideAccentAndIcon = false;
    toast.BorderColor = System.Drawing.ColorTranslator.FromHtml("#D3D3D3");
    toast.BackgroundColor = System.Drawing.ColorTranslator.FromHtml("#F5F5F5");
    toast.HeaderText = "Staging:";
    toast.MessageText = message;
    toast.ShowToast();

    return toast;
}

// This code is in another class.
public void StageReleaseSet(IProgress<string> progress)
{
    foreach (ReleaseItem rs in formData.CurrentReleaseSet)
    {
        // Do lots of hard work here. In the real world the code is 
        // probably also asynchronous--but that doesn't change
        // the behavior reporting progress. 
        // Report the file just processed.
        progress.Report(rs.binary_filename);
    }
}


```



