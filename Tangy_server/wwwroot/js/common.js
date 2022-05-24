window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Successful', { timeOut: 5000 })
    }
    else if (type === "warning") {
        toastr.warning(message)
    }
    else if (type === "error") {
        toastr.error(message, 'Operation Failed!', { timeOut: 5000 })
    }
    else if (type === "clear") {
        toastr.clear()
    }
    else if (type === "remove") {
        toastr.remove()
    }
    else if (type === "warning") {
        toastr.warning(message)
    }
}

window.ShowSweetAlert = (title, message, icon, button) => {
    swal(
        {
            title: title,
            text: message,
            icon: icon,
            button: button,
        });
}