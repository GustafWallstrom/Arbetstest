
				<table width="600" cellspacing="0" cellpadding="0" border="0">
				<tr><td>
				<h1 style="margin-bottom:2px;font-size:30px;margin: 0 0 18px;">Ny kommentar</h1>
				<table border="0" cellpadding="0" cellspacing="0">
					<tr>
						<td style="width:84px;text-align:center;vertical-align: top;">
							<img src="${comment.AvatarUrl}" alt="${comment.Name}" />
						</td>
						<td style="vertical-align: top;">
							<h2 style="font-size: 14px;margin: 0 0 8px 0; color:#2585b2">${comment.Name} kommenterade p&#229; <a style="text-decoration:underline;color:#2585b2" href=" ${hostUrl}${comment.PageLink} ">${page.HtmlTitle}</a>.</h1>
							<p style="font-size: 14px;margin: 0 0 8px 0;">
								${comment.Message}
							</p>
						</td>
					</tr>
					<tr>
						<td></td>
						<td style="vertical-align: top;">
							#if ( $comment.Status.ToString() == "Approve" )
								<a style="text-decoration:underline;color:#2585b2" href=" ${hostUrl}${comment.PageLink}/cact-hold/cid-${comment.Id}">F&#246;rkasta</a>
							#else
								<a style="text-decoration:underline;color:#2585b2" href=" ${hostUrl}${comment.PageLink}/cact-approve/cid-${comment.Id}">Godk&#228;nn</a>
							#end
							 | 
							#if ( $comment.Status.ToString() == "Spam" )
								<a style="text-decoration:underline;color:#2585b2" href=" ${hostUrl}${comment.PageLink}/cact-spam/cid-${comment.Id}">Ej skr&#228;ppost</a>
							#else
								<a style="text-decoration:underline;color:#2585b2" href=" ${hostUrl}${comment.PageLink}/cact-notspam/cid-${comment.Id}">Skr&#228;ppost</a>
							#end
							 |
							 <a style="text-decoration:underline;color:#2585b2" href=" ${hostUrl}${comment.PageLink}/cact-delete/cid-${comment.Id}">Ta bort</a>
						</td>
					</tr>
				</table>
				<p style="margin-top:25px; font-size:12px;">
					<b>Mer information om ${comment.Name}</b>
					<br />Skickat: $comment.Time.ToString("dd MMMM HH:mm")
					<br />IP: ${comment.Ip}
					<br />E-post: ${comment.Email}
					#if ( $comment.Website && $comment.Website != "" ) 
						<br />Webbplats: ${comment.Website}
					#end
					#if ( $comment.ExtraField1 && $comment.ExtraField1 != "" ) 
						<br />Extra: ${comment.ExtraField1}
					#end
				</p>
					
			</td></tr>
				
				</table>
		