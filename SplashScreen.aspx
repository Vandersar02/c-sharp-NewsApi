<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SplashScreen.aspx.cs" Inherits="DevoirAPI.SplashScreen" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-KK94CHFLLe+nY2dmCWGMq91rCGa5gtU4mk92HdvYe+M/SXH301p5ILy+dN9+nJOZ" crossorigin="anonymous"/>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link rel="Website Icon" type="jpg" href="imaj.jpg"/>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.7.2/font/bootstrap-icons.css" rel="stylesheet"/>

    <title>Splash Screen</title>

    <style>
        .splash-screen {
            position: fixed;
            top: 0;
            left: 0;    
            width: 100%;
            height: 100vh;
            background-color: #d8d8d8;
            display: flex;
            justify-content: center;
            align-items: center;
        }

        #typing-text {
            color: #000000;
            font-size: 70px;
            font-weight: bold;
            white-space: nowrap;
            overflow: hidden;
            animation: typing 10s steps(100) linear;
        }

        .progress-bar-container {
            width: 300px;
            height: 20px;
            margin-top: 10px;
            background-color: #d8d8d8;
        }

        #progress {
            height: 100%;
            background-color: #1549fa;
            width: 0;
            transition: width 0.5s ease-in-out;

        }

        @keyframes typing {
            0% {
                width: 0;
            }
            100% {
                width: 100%;
            }
        }

    </style>

</head>
<body>
    <form id="form1" runat="server">
    <div class="splash-screen">
        <div class="col-4"></div>

        <div class="col-4">
            
            <%--Cet icon servira a montrer en vert ( si on est online) et rouge (si on n'est pas online)--%>
            <i id="connection-icon" class="bi bi-exclamation-circle"></i> 

            <div class="row">

                <h1 id="typing-text"> </h1>
            </div>

            <div class="row justify-content-center align-items-center">
                <div class="col-md-9">
                    <div class="progress-bar-container">
                        <div class="progress" id="progress"></div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-4"></div>
    </div>

    <script>
        var text = "Popular News"; // Texte à afficher
        var speed = 100;// Vitesse de frappe (en millisecondes)
        var progress = 0;

        function typeWriter(text, index) {
            if (index < text.length) {
                document.getElementById("typing-text").innerHTML += text.charAt(index);
                index++;
                setTimeout(function () {
                    typeWriter(text, index);
                }, speed);
            }
        }

        function updateProgress() {

            if (progress < 100) {
                progress++;
                document.getElementById("progress").style.width = progress + "%";
                setTimeout(function () {
                    updateProgress();
                }, speed);
            } else if (progress == 100) {
                // Progress bar atteint les 100%, on passe a l' ecran WebNews'
                setTimeout(function () {
                    window.location.href = "WebNews.aspx";
                }, 2000); // Temps d'attente avant de passer à l'écran suivant (en millisecondes)

            }
        }
        var connectionIcon = document.getElementById("connection-icon");

        function updateConnectionStatus() {
            if (navigator.onLine) {
                connectionIcon.classList.remove("text-danger");
                connectionIcon.classList.add("text-success");
            } else {
                connectionIcon.classList.remove("text-success");
                connectionIcon.classList.add("text-danger");
            }
        }

        window.onload = function () {
            typeWriter(text, 0);
            updateProgress();
            updateConnectionStatus();
        };


        window.addEventListener("online", updateConnectionStatus);
        window.addEventListener("offline", updateConnectionStatus);

    </script>

    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/bootstrap.js"></script>
</body>
</html>
