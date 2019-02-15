![logo](https://github.com/Jungwoo-An/SweetAlertSharp/raw/master/static/logo.png)

beautiful, simply, alternative for MessageBox class.
inspired by [sweetalert2](https://github.com/sweetalert2/sweetalert2)

## Preview

![preview](https://github.com/Jungwoo-An/SweetAlertSharp/raw/master/static/preview.gif)

## Installation

```bash
PM> Install-Package SweetAlertSharp
```

## Usage

**Basic**

```cs
const result = SweetAlert.Show("Caption", "Content");
```

**Yes No**

```cs
const result = SweetAlert.Show("Caption", "Content", SweetAlertButton.YesNo);
```

**With Icon**

```cs
const result = SweetAlert.Show("Caption", "Content", msgImage: SweetAlertImage.INFORMATION);
```

**Custom Button Text**

```cs
var alert = new SweetAlert();
alert.Caption = "Custom Alert";
alert.Message = "Content";
alert.MsgButton = SweetAlertButton.YesNo;
alert.OkText = "Yes.";
alert.CancelText = "No!";

SweetAlertResult result = alert.ShowDialog();
```

**Custom Button Layout**

```cs
var alert = new SweetAlert();
alert.Caption = "Custom Layout";
alert.Message = "Content";
alert.ButtonContent = new StackPanel();

SweetAlertResult result = alert.ShowDialog();
```

**Delay (ex: loading)**

```cs
var canClose = false;
var alert = new SweetAlert();
alert.Caption = "Delay";
alert.Message = "Wait!";
alert.ButtonContent = "Loading ...";
alert.PreClose += (object window, CancelEventArgs cancelEvent) =>
{
    cancelEvent.Cancel = !canClose;
};

Task.Run(async () =>
{
    await Task.Delay(3000);
    await Dispatcher.BeginInvoke(new Action(() =>
    {
        canClose = true;

        alert.ButtonContent = "Ok!";
    }));
});

var reuslt = alert.ShowDialog();
```
