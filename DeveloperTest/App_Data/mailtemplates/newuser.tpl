
		<table width="600" cellspacing="0" cellpadding="0" border="0">
			<tr><td>
				<h1 style="margin-bottom:2px;font-size:30px;">Nytt anv&#228;ndarkonto</h1>
				<p style="font-size: 14px;">
					Hej!
					<br/>
					H&#228;r kommer inloggningsuppgifterna f&#246;r ditt nya anv&#228;ndarkonto.
				</p>
				<p>
					<table border="0" cellspacing="0" cellpadding="0">
						#if ( $username )
						<tr>
							<td style="font-size: 14px; padding-right: 8px;"><b>Anv&#228;ndarnamn</b></td>
							<td style="font-size: 14px;"> $username </td>
						</tr>
						#end
						<tr>
							<td style="font-size: 14px; padding-right: 8px;"><b>L&#246;senord</b></td>
							<td style="font-size: 14px;"> $password </td>
						</tr>
					</table>
				</p>				
			</td></tr>
		</table>
		