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
const result = SweetAlert.Show("Caption", "Content", MessageBoxButton.YesNo);
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
alert.MsgButton = MessageBoxButton.YesNo;
alert.OkText = "Yes.";
alert.CancelText = "No!";

alert.ShowDialog();

// alert.Result
```
