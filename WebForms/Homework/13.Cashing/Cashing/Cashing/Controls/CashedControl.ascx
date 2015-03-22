<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CashedControl.ascx.cs" Inherits="Cashing.Controls.CashedControl" %>
<%@ OutputCache Duration="10" VaryByParam="none" %>

<p><%: DateTime.Now.ToString() %></p>