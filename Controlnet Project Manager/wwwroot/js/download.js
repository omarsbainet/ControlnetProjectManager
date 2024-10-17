< !DOCTYPE html >
    <html>
        <head>
            <meta charset="utf-8" />
            <title>My Blazor App</title>
            <base href="/" />
            <script src="js/download.js"></script> <!-- Agrega esta línea para cargar el archivo JavaScript -->
        </head>
        <body>
            <app>
                @(await Html.RenderComponentAsync<App>(RenderMode.ServerPrerendered))
            </app>

            <script src="_framework/blazor.server.js"></script>
        </body>
    </html>
