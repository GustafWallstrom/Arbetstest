
		<table width="600" cellspacing="0" cellpadding="0" border="0">
			<tr><td>
				<h1 style="margin-bottom:2px;font-size:30px;">Nytt l&#246;senord</h1>
				<p style="font-size: 14px;">
					Hej!
					<br/>
					Här kommer ditt nya l&#246;senord.
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

				#if ( $ip )
				<p style="font-size:12px;">
					<i>Om du inte beg&#228;rt ett nytt l&#246;senord s&#229; har n&#229;gon annnan f&#246;rs&#246;kt att komma &#229;t din anv&#228;ndare, de kommer inte f&#229; ditt l&#246;senord, om uppgifterna inte tillh&#246;r din anv&#228;ndare kan du kontakta oss enligt uppgifter nedan
						#if ( $ip && $ip != "" )
							(Beg&#228;ran om nytt l&#246;senord kom fr&#229;n IP: ${ip})
						#end
						.
					</i>
				</p>
				#end
				
				
			</td></tr>
		</table>
		