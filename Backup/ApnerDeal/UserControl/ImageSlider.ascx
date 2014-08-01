<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImageSlider.ascx.cs" Inherits="UserControl_ImageSlider" %>


<link href="../CSS/sitemain.css" rel="stylesheet" type="text/css" />    
<link href="../CSS/imageslider.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="../Script/jquery.js"></script>

<script type="text/javascript" src="../Script/easySlider1.5.js"></script>

<script type="text/javascript">
		$(document).ready(function(){	
			$("#slider").easySlider({
				auto: true,
				continuous: true,
				Speed: 3500
			});
		});	
    </script>

<body>
    
        <div id="content">
            <div id="slider">
                <ul>
                    <li><a href="http://touch">
                        <img src="../images/01.jpg" alt="Css Template Preview" /></a></li>
                    <li><a href="http://templatica.com/preview/7">
                        <img src="../images/02.jpg" alt="Css Template Preview" /></a></li>
                    <li><a href="http://templatica.com/preview/25">
                        <img src="../images/03.jpg" alt="Css Template Preview" /></a></li>
                    <li><a href="http://templatica.com/preview/26">
                        <img src="../images/04.jpg" alt="Css Template Preview" /></a></li>
                    <li><a href="http://templatica.com/preview/27">
                        <img src="../images/05.jpg" alt="Css Template Preview" /></a></li>
                </ul>
            </div>
        </div>

</body>
