<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Proyecto3Capas.Secciones.Home" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container">
        <div class="row">
            <div class="col-md-12">
                <br /><br /><br />
                <br /><br /><br />
                <h3 class="tit2 t-center">Salon de Eventos Sociales Sidney</h3>
                <br /><br /><br />
            </div>
        </div>

        <!-- Welcome -->
	    <section class="section-welcome bg1-pattern p-t-120 p-b-105">
		    <div class="container">
			    <div class="row">
				    <div class="col-md-6 p-t-45 p-b-30">
					    <div class="wrap-text-welcome t-center">
						    <span class="tit2 t-center">
							    Salon de Eventos
						    </span>

						    <h3 class="tit3 t-center m-b-35 m-t-5">
							    Bienvenido
						    </h3>

						    <p class="t-center m-b-22 size3 m-l-r-auto">
							    El salón de eventos sociales Sidney es reconocido por sus inigualables instalaciones, así como sus grandes eventos que se llevan acabo cada semana.
						    </p>

						    <%--<a href="about.html" class="txt4">
							    Our Story
							    <i class="fa fa-long-arrow-right m-l-10" aria-hidden="true"></i>
						    </a>--%>
					    </div>
				    </div>

				    <div class="col-md-6 p-b-30">
					    <div class="wrap-pic-welcome size2 bo-rad-10 hov-img-zoom m-l-r-auto">
						    <img src="/images/our-story-01.jpg" alt="IMG-OUR">
					    </div>
				    </div>
			    </div>
		    </div>
	    </section>


         <!-- Intro -->
	    <section class="section-intro">
		    <span class="tit2 p-l-15 p-r-15">
			    Elige tu evento
		    </span>

		    <div class="content-intro bg-white p-t-77 p-b-133">
			    <div class="container">
				    <div class="row">
					    <div class="col-md-4 p-t-30">
						    <!-- Block1 -->
						    <div class="blo1">
							    <div class="wrap-pic-blo1 bo-rad-10 hov-img-zoom">
								    <a href="#"><img src="/images/intro-01.jpg" alt="IMG-INTRO"></a>
							    </div>

							    <div class="wrap-text-blo1 p-t-35">
								    <a href="#"><h4 class="txt5 color0-hov trans-0-4 m-b-13">
									    15 Años
								    </h4></a>

								    <p class="m-b-20">
									    Elige tener tu fiesta de quince años aquí y recibiras grandes descuentos si es en el mismo mes en que los cumples.
								    </p>
                                    <a href="/Catalogos/TipoEventos/ListaTipoEventos.aspx" class="txt4">
                                        Leer Más
									    <i class="fa fa-long-arrow-right m-l-10" aria-hidden="true"></i>
                                    </a>
							    </div>
						    </div>
					    </div>

					    <div class="col-md-4 p-t-30">
						    <!-- Block1 -->
						    <div class="blo1">
							    <div class="wrap-pic-blo1 bo-rad-10 hov-img-zoom">
								    <a href="#"><img src="/images/intro-02.jpg" alt="IMG-INTRO"></a>
							    </div>

							    <div class="wrap-text-blo1 p-t-35">
								    <a href="#"><h4 class="txt5 color0-hov trans-0-4 m-b-13">
									    Bodas
								    </h4></a>

								    <p class="m-b-20">
									    Grandes evetos de bodas se podran llevae acabo en este gran salon de fiestas
								    </p>
                                    <a href="/Catalogos/TipoEventos/ListaTipoEventos.aspx" class="txt4">
                                        Leer Más
									    <i class="fa fa-long-arrow-right m-l-10" aria-hidden="true"></i>
                                    </a>
							    </div>
						    </div>
					    </div>

					    <div class="col-md-4 p-t-30">
						    <!-- Block1 -->
						    <div class="blo1">
							    <div class="wrap-pic-blo1 bo-rad-10 hov-img-zoom">
								    <a href="#"><img src="/images/intro-04.jpg" alt="IMG-INTRO"></a>
							    </div>

							    <div class="wrap-text-blo1 p-t-35">
								    <a href="#"><h4 class="txt5 color0-hov trans-0-4 m-b-13">
									    Eventos infantiles
								    </h4></a>

								    <p class="m-b-20">
									    Grandes fiestas para niños se llevan cada fin de semana aquí en Sidney
								    </p>

								   <a href="/Catalogos/TipoEventos/ListaTipoEventos.aspx" class="txt4">
                                        Leer Más
									    <i class="fa fa-long-arrow-right m-l-10" aria-hidden="true"></i>
                                    </a>
							    </div>
						    </div>
					    </div>

				    </div>
			    </div>
		    </div>
	    </section>

         <!-- Our menu -->
	    <section class="section-ourmenu bg2-pattern p-t-115 p-b-120">
		    <div class="container">
			    <div class="title-section-ourmenu t-center m-b-22">
				    <span class="tit2 t-center">
					    Descubre nuestro salón
				    </span>

				    <h3 class="tit5 t-center m-t-2">
					    Fotos
				    </h3>
			    </div>

			    <div class="row">
				    <div class="col-md-8">
					    <div class="row">
						    <div class="col-sm-6">
							    <!-- Item our menu -->
							    <div class="item-ourmenu bo-rad-10 hov-img-zoom pos-relative m-t-30">
								    <img src="/images/our-menu-01.jpg" alt="IMG-MENU">

								    <!-- Button2 
								    <a href="#" class="btn2 flex-c-m txt5 ab-c-m size4">
									    Lunch
								    </a>-->
							    </div>
						    </div>

						    <div class="col-sm-6">
							    <!-- Item our menu -->
							    <div class="item-ourmenu bo-rad-10 hov-img-zoom pos-relative m-t-30">
								    <img src="/images/our-menu-05.jpg" alt="IMG-MENU">

								    <!-- Button2
								    <a href="#" class="btn2 flex-c-m txt5 ab-c-m size5">
									    Dinner 
								    </a>--> 
							    </div>
						    </div>

						    <div class="col-12">
							    <!-- Item our menu -->
							    <div class="item-ourmenu bo-rad-10 hov-img-zoom pos-relative m-t-30">
								    <img src="/images/our-menu-13.jpg" alt="IMG-MENU">

								    <!-- Button2 
								    <a href="#" class="btn2 flex-c-m txt5 ab-c-m size6">
									    Happy Hour
								    </a>-->
							    </div>
						    </div>
					    </div>
				    </div>

				    <div class="col-md-4">
					    <div class="row">
						    <div class="col-12">
							    <!-- Item our menu -->
							    <div class="item-ourmenu bo-rad-10 hov-img-zoom pos-relative m-t-30">
								    <img src="/images/our-menu-08.jpg" alt="IMG-MENU">

								    <!-- Button2 
								    <a href="#" class="btn2 flex-c-m txt5 ab-c-m size7">
									    Drink
								    </a>-->
							    </div>
						    </div>

						    <div class="col-12">
							    <!-- Item our menu -->
							    <div class="item-ourmenu bo-rad-10 hov-img-zoom pos-relative m-t-30">
								    <img src="/images/our-menu-10.jpg" alt="IMG-MENU">

								    <!-- Button2 
								    <a href="#" class="btn2 flex-c-m txt5 ab-c-m size8">
									    Starters
								    </a>-->
							    </div>
						    </div>

						    <div class="col-12">
							    <!-- Item our menu -->
							    <div class="item-ourmenu bo-rad-10 hov-img-zoom pos-relative m-t-30">
								    <img src="/images/our-menu-16.jpg" alt="IMG-MENU">

								    <!-- Button2 
								    <a href="#" class="btn2 flex-c-m txt5 ab-c-m size9">
									    Dessert
								    </a>-->
							    </div>
						    </div>
					    </div>
				    </div>
			    </div>

		    </div>
	    </section>




    </div>
</asp:Content>
