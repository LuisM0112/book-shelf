document.querySelectorAll(".confirm-form").forEach(form => {

    form.addEventListener("submit", async function (event) {

        event.preventDefault();

        const result = await Swal.fire({
            title: form.dataset.title,
            text: form.dataset.text,
            icon: form.dataset.icon ?? "warning",
            showCancelButton: true,
            confirmButtonText: form.dataset.confirmButton ?? "Aceptar",
            cancelButtonText: "Cancelar",
            reverseButtons: true
        });

        if (result.isConfirmed) {
            form.submit();
        }

    });

});

const messageContainer = document.getElementById("sweetalert-message");

if (messageContainer) {

    Swal.fire({
        icon: messageContainer.dataset.icon,
        title: messageContainer.dataset.title,
        text: messageContainer.dataset.text,
        confirmButtonText: "Aceptar"
    });

}
