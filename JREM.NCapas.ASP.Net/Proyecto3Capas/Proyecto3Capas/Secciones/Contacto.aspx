<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="Proyecto3Capas.Secciones.Contacto" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Contact form -->
	<section class="section-contact bg1-pattern p-t-90 p-b-113">
		<!-- Map -->
		
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
							    No olvides ponerte en contacto con nosotros
						    </h3>
					    </div>
				    </div>

				    <div class="col-md-6 p-b-30">
					    <div class="wrap-pic-welcome size2 bo-rad-10 hov-img-zoom m-l-r-auto">
						    <img src="/images/photo-gallery-thumb-03.jpg" alt="IMG-OUR">
					    </div>
				    </div>
			    </div>
		    </div>


		<div class="container">
			<h3 class="tit7 t-center p-b-62 p-t-105">
				Envíanos un  Mensaje
			</h3>

			<form class="wrap-form-reservation size22 m-l-r-auto">
				<div class="row">
					<div class="col-md-4">
						<!-- Name -->
						<span class="txt9">
							Nombre
						</span>

						<div class="wrap-inputname size12 bo2 bo-rad-10 m-t-3 m-b-23">
							<input class="bo-rad-10 sizefull txt10 p-l-20" type="text" name="name" placeholder="Nombre">
						</div>
					</div>

					<div class="col-md-4">
						<!-- Email -->
						<span class="txt9">
							Email
						</span>

						<div class="wrap-inputemail size12 bo2 bo-rad-10 m-t-3 m-b-23">
							<input class="bo-rad-10 sizefull txt10 p-l-20" type="text" name="email" placeholder="Email">
						</div>
					</div>

					<div class="col-md-4">
						<!-- Phone -->
						<span class="txt9">
							Teléfono
						</span>

						<div class="wrap-inputphone size12 bo2 bo-rad-10 m-t-3 m-b-23">
							<input class="bo-rad-10 sizefull txt10 p-l-20" type="text" name="phone" placeholder="Teléfono">
						</div>
					</div>

					<div class="col-12">
						<!-- Message -->
						<span class="txt9">
							Mensaje
						</span>
						<textarea class="bo-rad-10 size35 bo2 txt10 p-l-20 p-t-15 m-b-10 m-t-3" name="message" placeholder="Mensaje"></textarea>
					</div>
				</div>

				<div class="wrap-btn-booking flex-c-m m-t-13">
					<!-- Button3 -->
					<button type="submit" class="btn3 flex-c-m size36 txt11 trans-0-4">
						Enviar
					</button>
				</div>
			</form>
		</div>
	</section>


</asp:Content>
