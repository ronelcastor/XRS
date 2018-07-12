<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/principal.Master" AutoEventWireup="true" CodeBehind="cashTaxReport.aspx.cs" Inherits="CTRSv3.WebFormCashTaxReport" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
			<ContentTemplate>
				<div class="">
					<div class="page-title">
						<div class="title_left">
						<h3>Cash Tax Reports</h3>
						</div>
						<%--<div class="title_right">
							<div class="col-md-5 col-sm-5 col-xs-12 form-group pull-right top_search">
								<div class="input-group">
								<input type="text" class="form-control" placeholder="Search for...">
								<span class="input-group-btn">
									<button class="btn btn-default" type="button">Go!</button>
								</span>
								</div>
							</div>
						</div>--%>
					</div>
					<div class="clearfix"></div>
					<div class="row">
						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="x_panel">
								<div class="x_title">
								<h2>Report Filtering</h2>
								<ul class="nav navbar-right panel_toolbox">
									<li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
									</li>
									<li><a class="close-link"><i class="fa fa-close"></i></a>
									</li>
								</ul>
								<div class="clearfix"></div>
								</div>
								<div class="x_content">
								<br />
								    <div class="form-group">
									    <label class="control-label col-md-1 left" style="text-align: left;" for="first-name">Region <span class="required">*</span>
									    </label>
									    <div class="col-md-3">
										    <asp:DropDownList ID="ddlRegion" runat="server" class="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" >
										    </asp:DropDownList>
										    &nbsp;</div>
									    <label class="control-label col-md-1 left" style="text-align: left;" for="last-name">Period Date <span class="required">*</span>
									    </label>
									    <div class="col-md-3">
										    <asp:DropDownList ID="ddlPeriod" runat="server" class="form-control" DataTextFormatString="{0:MM/dd/yyyy}" AutoPostBack="True">
										    </asp:DropDownList>
									    </div>
                                        <label class="control-label col-md-1 left" style="text-align: left;" for="last-name">Template <span class="required">*</span>
									    </label>
									    <div class="col-md-3">
										    <asp:DropDownList ID="ddlTemplate" runat="server" class="form-control" AutoPostBack="True">
										    </asp:DropDownList>
									    </div>
								    </div>
								</div>
							</div>
						</div>

						<div class="col-md-12 col-sm-12 col-xs-12">
							<div class="x_panel">
							  <div class="x_content">

								<%--<table id="datatable-responsive1" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
								  <thead>
									<tr>
									  <th>First name</th>
									  <th>Last name</th>
									  <th>Position</th>
									  <th>Office</th>
									  <th>Age</th>
									  <th>Start date</th>
									  <th>Salary</th>
									  <th>Extn.</th>
									  <th>E-mail</th>
									</tr>
								  </thead>
								  <tbody>
									<tr>
									  <td>Tiger</td>
									  <td>Nixon</td>
									  <td>System Architect</td>
									  <td>Edinburgh</td>
									  <td>61</td>
									  <td>2011/04/25</td>
									  <td>$320,800</td>
									  <td>5421</td>
									  <td>t.nixon@datatables.net</td>
									</tr>
									<tr>
									  <td>Garrett</td>
									  <td>Winters</td>
									  <td>Accountant</td>
									  <td>Tokyo</td>
									  <td>63</td>
									  <td>2011/07/25</td>
									  <td>$170,750</td>
									  <td>8422</td>
									  <td>g.winters@datatables.net</td>
									</tr>
									<tr>
									  <td>Ashton</td>
									  <td>Cox</td>
									  <td>Junior Technical Author</td>
									  <td>San Francisco</td>
									  <td>66</td>
									  <td>2009/01/12</td>
									  <td>$86,000</td>
									  <td>1562</td>
									  <td>a.cox@datatables.net</td>
									</tr>
									<tr>
									  <td>Cedric</td>
									  <td>Kelly</td>
									  <td>Senior Javascript Developer</td>
									  <td>Edinburgh</td>
									  <td>22</td>
									  <td>2012/03/29</td>
									  <td>$433,060</td>
									  <td>6224</td>
									  <td>c.kelly@datatables.net</td>
									</tr>
									<tr>
									  <td>Airi</td>
									  <td>Satou</td>
									  <td>Accountant</td>
									  <td>Tokyo</td>
									  <td>33</td>
									  <td>2008/11/28</td>
									  <td>$162,700</td>
									  <td>5407</td>
									  <td>a.satou@datatables.net</td>
									</tr>
									<tr>
									  <td>Brielle</td>
									  <td>Williamson</td>
									  <td>Integration Specialist</td>
									  <td>New York</td>
									  <td>61</td>
									  <td>2012/12/02</td>
									  <td>$372,000</td>
									  <td>4804</td>
									  <td>b.williamson@datatables.net</td>
									</tr>
									<tr>
									  <td>Herrod</td>
									  <td>Chandler</td>
									  <td>Sales Assistant</td>
									  <td>San Francisco</td>
									  <td>59</td>
									  <td>2012/08/06</td>
									  <td>$137,500</td>
									  <td>9608</td>
									  <td>h.chandler@datatables.net</td>
									</tr>
									<tr>
									  <td>Rhona</td>
									  <td>Davidson</td>
									  <td>Integration Specialist</td>
									  <td>Tokyo</td>
									  <td>55</td>
									  <td>2010/10/14</td>
									  <td>$327,900</td>
									  <td>6200</td>
									  <td>r.davidson@datatables.net</td>
									</tr>
									<tr>
									  <td>Colleen</td>
									  <td>Hurst</td>
									  <td>Javascript Developer</td>
									  <td>San Francisco</td>
									  <td>39</td>
									  <td>2009/09/15</td>
									  <td>$205,500</td>
									  <td>2360</td>
									  <td>c.hurst@datatables.net</td>
									</tr>
									<tr>
									  <td style="height: 53px">Sonya</td>
									  <td style="height: 53px">Frost</td>
									  <td style="height: 53px">Software Engineer</td>
									  <td style="height: 53px">Edinburgh</td>
									  <td style="height: 53px">23</td>
									  <td style="height: 53px">2008/12/13</td>
									  <td style="height: 53px">$103,600</td>
									  <td style="height: 53px">1667</td>
									  <td style="height: 53px">s.frost@datatables.net</td>
									</tr>
									<tr>
									  <td style="height: 52px">Jena</td>
									  <td style="height: 52px">Gaines</td>
									  <td style="height: 52px">Office Manager</td>
									  <td style="height: 52px">London</td>
									  <td style="height: 52px">30</td>
									  <td style="height: 52px">2008/12/19</td>
									  <td style="height: 52px">$90,560</td>
									  <td style="height: 52px">3814</td>
									  <td style="height: 52px">j.gaines@datatables.net</td>
									</tr>
								  </tbody>
								</table>--%>
					
					
							  </div>
								<asp:ListView ID="lvReport" runat="server" DataSourceID="sdsReport">
									<EmptyDataTemplate>
										<table runat="server" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
											<tr>
												<td>No data was returned.</td>
											</tr>
										</table>
									</EmptyDataTemplate>
									<ItemTemplate>
										<tr style="">
											<td>
												<asp:Label ID="COUNTRYLabel" runat="server" Text='<%# Eval("COUNTRY") %>' />
											</td>
											<td>
												<asp:Label ID="Reporting_EntityLabel" runat="server" Text='<%# Eval("Reporting_Entity") %>' />
											</td>
											<td>
												<asp:Label ID="ENTITIESLabel" runat="server" Text='<%# Eval("ENTITIES") %>' />
											</td>
											<td>
												<asp:Label ID="ENTITY_NAMELabel" runat="server" Text='<%# Eval("ENTITY_NAME") %>' />
											</td>
											<td>
												<asp:Label ID="TEMPLATELabel" runat="server" Text='<%# Eval("TEMPLATE") %>' />
											</td>
											<td>
												<asp:Label ID="ESSLabel" runat="server" Text='<%# string.Format("{0:#,0.00}", Eval("ESS")) %>'  class="pull-right"/>
											</td>
											<td>
												<asp:Label ID="SubmissionLabel" runat="server" Text='<%# string.Format("{0:#,0.00}", Eval("Submission")) %>' class="pull-right" />
											</td>
										</tr>
									</ItemTemplate>
									<LayoutTemplate>
										<table runat="server" class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
											<tr runat="server">
												<td runat="server">
													<table id="itemPlaceholderContainer" runat="server"  class="table table-striped table-bordered dt-responsive nowrap" cellspacing="0" width="100%">
														<tr runat="server" style="">
															<th runat="server">COUNTRY</th>
															<th runat="server">Reporting_Entity</th>
															<th runat="server">ENTITIES</th>
															<th runat="server">ENTITY_NAME</th>
															<th runat="server">TEMPLATE</th>
															<th runat="server">ESS</th>
															<th runat="server">Submission</th>
														</tr>
														<tr runat="server" id="itemPlaceholder">
														</tr>
													</table>
												</td>
											</tr>
											<tr runat="server">
												<td runat="server" style="">
													<asp:DataPager ID="DataPager1" runat="server">
														<Fields>
															<asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
															<asp:NumericPagerField />
															<asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
														</Fields>
													</asp:DataPager>
												</td>
											</tr>
										</table>
									</LayoutTemplate>
						
									<SelectedItemTemplate>
										<tr style="">
											<td>
												<asp:Label ID="COUNTRYLabel" runat="server" Text='<%# Eval("COUNTRY") %>' />
											</td>
											<td>
												<asp:Label ID="Reporting_EntityLabel" runat="server" Text='<%# Eval("Reporting_Entity") %>' />
											</td>
											<td>
												<asp:Label ID="ENTITIESLabel" runat="server" Text='<%# Eval("ENTITIES") %>' />
											</td>
											<td>
												<asp:Label ID="ENTITY_NAMELabel" runat="server" Text='<%# Eval("ENTITY_NAME") %>' />
											</td>
											<td>
												<asp:Label ID="TEMPLATELabel" runat="server" Text='<%# Eval("TEMPLATE") %>' />
											</td>
											<td>
												<asp:Label ID="ESSLabel" runat="server" Text='<%# string.Format("{0:#,0.00}", Eval("ESS")) %>' />
											</td>
											<td>
												<asp:Label ID="SubmissionLabel" runat="server" Text='<%# string.Format("{0:#,0.00}", Eval("Submission")) %>' />
											</td>
										</tr>
									</SelectedItemTemplate>
								</asp:ListView>
								<asp:SqlDataSource ID="sdsReport" runat="server" ConnectionString="<%$ ConnectionStrings:TWDConnectionString %>" SelectCommand="SELECT COUNTRY, [Reporting Entity] AS Reporting_Entity, ENTITIES, [ENTITY NAME] AS ENTITY_NAME, TEMPLATE, (SELECT ISNULL(SUM(Value), 0) AS Expr1 FROM [Vw_ESS Validation using new XRef Table] AS essTbl WHERE (REGION = @REGION) AND (Period = @Period) AND (Source = 'ESS') AND (VXT.COUNTRY = COUNTRY) AND (VXT.[Reporting Entity] = [Reporting Entity]) AND (VXT.ENTITIES = ENTITIES) AND (VXT.[ENTITY NAME] = [ENTITY NAME]) AND (TEMPLATE = @Template)) AS ESS, (SELECT ISNULL(SUM(Value), 0) AS Expr1 FROM [Vw_ESS Validation using new XRef Table] AS subTbl WHERE (REGION = @REGION) AND (Period = @Period) AND (Source = 'Submission') AND (VXT.COUNTRY = COUNTRY) AND (VXT.[Reporting Entity] = [Reporting Entity]) AND (VXT.ENTITIES = ENTITIES) AND (VXT.[ENTITY NAME] = [ENTITY NAME]) AND (TEMPLATE = @Template)) AS Submission FROM [Vw_ESS Validation using new XRef Table] AS VXT WHERE (REGION = @REGION) AND (Period = @Period) AND (TEMPLATE = @Template) GROUP BY COUNTRY, [Reporting Entity], ENTITIES, [ENTITY NAME], TEMPLATE">
									<SelectParameters>
										<asp:ControlParameter ControlID="ddlRegion" Name="REGION" PropertyName="SelectedValue" Type="String" />
										<asp:ControlParameter ControlID="ddlPeriod" Name="Period" PropertyName="SelectedValue" Type="DateTime" />
									    <asp:ControlParameter ControlID="ddlTemplate" Name="Template" PropertyName="SelectedValue" />
									</SelectParameters>
								</asp:SqlDataSource>
							</div>
						  </div>
					</div>
		
				</div>
			</ContentTemplate>
		</asp:UpdatePanel>
</asp:Content>
