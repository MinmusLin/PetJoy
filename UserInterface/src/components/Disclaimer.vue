<!--
  Project Name:  UserInterface
  File Name:     Disclaimer.vue
  File Function: 免责声明组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-26
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <!--德语版本-->
  <el-container direction='vertical' v-if="$i18n.locale == 'de'">
    <p>Willkommen auf der Plattform PetJoy. Bevor Sie die Dienste der PetJoy-Plattform (im Folgenden als "die Plattform" bezeichnet) nutzen, lesen Sie bitte diese Erklärung sorgfältig durch und stellen Sie sicher, dass Sie sie vollständig verstehen. Sie können sich entscheiden, die Plattform nicht zu nutzen, aber wenn Sie sie nutzen, wird Ihr Verhalten als Anerkennung des gesamten Inhalts dieser Erklärung angesehen.</p>
    <p>Die spezifischen Haftungsausschlüsse sind wie folgt:</p>

    <h1>Informationenveröffentlichung und Nutzung</h1>
    <ol>
      <li>Alle Informationen und Ressourcen, die von der Plattform bereitgestellt werden, einschließlich, aber nicht beschränkt auf Texte, Bilder, Audio- und Videomaterialien, Nutzerkommentare und Links zu Drittanbietern, stammen aus dem Internet, von Nutzern und Partnern. Die Plattform bemüht sich, die Genauigkeit und Vollständigkeit der Informationen zu gewährleisten, gibt jedoch keine ausdrücklichen oder impliziten Garantien für die Echtheit, Genauigkeit, Aktualität, Vollständigkeit und Wirksamkeit der Informationen.</li>
      <li>Die von den Nutzern auf PetJoy veröffentlichten Inhalte müssen den nationalen Gesetzen und Vorschriften sowie den Plattformregeln entsprechen und dürfen keine illegalen, rechtsverletzenden, falschen, irreführenden, beleidigenden oder anderweitig unangemessenen Inhalte enthalten. Die Plattform hat das Recht, Inhalte, die gegen Gesetze oder Plattformregeln verstoßen, zu löschen, zu blockieren oder anderweitig zu bearbeiten, übernimmt jedoch keine Verantwortung für von Nutzern veröffentlichte Inhalte.</li>
    </ol>

    <h1>Nutzung von Informationen und Risiken</h1>
    <ol>
      <li>Die Nutzer sollten die auf PetJoy erlangten Informationen selbst bewerten und beurteilen und tragen alle Risiken und Verantwortlichkeiten, die sich aus der Nutzung dieser Informationen ergeben. Die Plattform übernimmt keine Verantwortung für direkte oder indirekte Verluste, die Nutzern durch die Nutzung oder Abhängigkeit von den auf der Plattform bereitgestellten Informationen entstehen.</li>
      <li>Wenn Nutzer auf der Plattform interagieren, handeln oder kommunizieren, sollten sie die damit verbundenen Risiken sorgfältig abwägen; die Plattform dient nur als Vermittler für Informationsaustausch und übernimmt keine Verantwortung für Handlungen oder deren Ergebnisse.</li>
    </ol>

    <h1>Urheberrechte</h1>
    <ol>
      <li>Alle Inhalte auf PetJoy, einschließlich, aber nicht beschränkt auf Texte, Bilder, Audio, Video, Software, Programme und Seitendesign, sind urheberrechtlich geschützt und Eigentum der Plattform oder der entsprechenden Rechteinhaber. Ohne schriftliche Erlaubnis der Plattform oder der Rechteinhaber darf niemand die Inhalte der Plattform kopieren, weiterverbreiten, übertragen, adaptieren, kompilieren oder auf andere Weise verwenden.</li>
      <li>Die von den Nutzern auf der Plattform veröffentlichten Inhalte gelten als Lizenzierung der Plattform, um diese Inhalte weltweit kostenlos, nicht-exklusiv und sublicenzierbar zu nutzen, einschließlich zur Darstellung, Förderung und anderen legalen Zwecken.</li>
    </ol>

    <h1>Schutz der Privatsphäre der Nutzer</h1>
    <ol>
      <li>PetJoy legt großen Wert auf den Schutz der Privatsphäre der Nutzer und wird angemessene Maßnahmen ergreifen, um die Sicherheit der persönlichen Informationen der Nutzer zu schützen. Nutzer müssen beim Nutzen der Plattformdienste echte und genaue persönliche Informationen bereitstellen und sind für die Echtheit, Legalität und Gültigkeit ihrer Informationen verantwortlich.</li>
      <li>Sofern nicht durch Gesetze oder Vorschriften anders vorgeschrieben oder vom Nutzer anders vereinbart, wird die Plattform die persönlichen Informationen der Nutzer nicht an Dritte offenlegen, verkaufen oder teilen.</li>
    </ol>

    <h1>Rechtliche Verantwortung</h1>
    <ol>
      <li>Bei der Nutzung von PetJoy müssen die Nutzer die nationalen Gesetze und Vorschriften sowie die Plattformregeln einhalten. Für alle Folgen, die aus der Nichteinhaltung resultieren, trägt der Nutzer die Verantwortung. Die Plattform hat das Recht, je nach Situation gegen regelwidrige Nutzer Maßnahmen wie Einschränkung, Aussetzung oder Beendigung des Dienstes zu ergreifen und behält sich das Recht vor, rechtliche Schritte einzuleiten.</li>
    </ol>

    <p>Die Auslegungs- und Änderungsrechte dieser Haftungsausschlusserklärung liegen bei PetJoy. Die Plattform hat das Recht, den Inhalt dieser Erklärung jederzeit zu ändern; die geänderte Erklärung wird sofort nach ihrer Veröffentlichung wirksam. Nutzer sollten dies beachten und befolgen.</p>
    <p>PetJoy behält sich das Recht vor, die endgültige Auslegung dieser Erklärung im gesetzlich zulässigen Rahmen zu übernehmen.</p>

    <p style='text-align: right'>PetJoy Entwicklerteam</p>
    <p style='text-align: right'>8. Juli 2024</p>
  </el-container>

  <!--英语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'en'">
    <p>Welcome to the PetJoy platform. Before using the various services provided by the PetJoy platform (hereinafter referred to as "the platform"), please read and thoroughly understand this statement. You may choose not to use the platform, but if you do use the platform, your actions will be considered as acceptance of the entire contents of this statement.</p>
    <p>The specific disclaimer is as follows:</p>

    <h1>Information Publishing and Usage</h1>
    <ol>
      <li>All information and resources provided by the platform, including but not limited to text, images, audio-visual materials, user comments, and third-party links, are sourced from the internet, users, and partners. The platform strives to ensure the accuracy and completeness of the information but does not make any express or implied warranties regarding the truthfulness, accuracy, timeliness, completeness, and effectiveness of the information.</li>
      <li>Content posted by users on PetJoy must comply with national laws and regulations and platform rules, and must not contain illegal, infringing, false, misleading, offensive, or other inappropriate content. The platform has the right to delete, block, or otherwise handle content suspected of violating laws and regulations or platform rules, but it does not assume any responsibility for user-posted content.</li>
    </ol>

    <h1>Usage of Information and Risks</h1>
    <ol>
      <li>Users should discern and judge the information obtained on PetJoy on their own and bear the risks and responsibilities associated with using such information. The platform is not liable for any direct or indirect losses caused by the use of or reliance on information on the platform.</li>
      <li>When engaging in communication, transactions, and interactions on the platform, users should judiciously assess the relevant risks. The platform only acts as an intermediary for information exchange and is not responsible for any trading actions and their outcomes.</li>
    </ol>

    <h1>Intellectual Property Rights</h1>
    <ol>
      <li>All content on PetJoy (including but not limited to text, images, audio, video, software, program, page design, etc.) is owned by the platform or relevant rights holders. Without written permission from the platform or the rights holder, no one may copy, reproduce, transmit, adapt, compile, or otherwise use the content of the platform.</li>
      <li>Content published by users on the platform is deemed as granting the platform a free, non-exclusive, sublicensable right and license to use such content globally in displaying, promoting, and other lawful ways.</li>
    </ol>

    <h1>User Privacy Protection</h1>
    <ol>
      <li>PetJoy values the protection of user privacy and will take reasonable measures to ensure the security of users' personal information. Users must provide true, accurate personal information when using the platform's services and are responsible for the truthfulness, legality, and effectiveness of their information.</li>
      <li>Unless otherwise stipulated by laws and regulations or agreed by the user, the platform will not disclose, sell, or share user's personal information to third parties.</li>
    </ol>

    <h1>Legal Responsibilities</h1>
    <ol>
      <li>When using PetJoy, users must comply with national laws and regulations and platform rules. Users will bear all consequences for violations. The platform reserves the right to take measures such as restrictions, suspension, or termination of services for users violating the rules, and retains the right to pursue legal responsibility.</li>
    </ol>

    <p>The right to interpret and modify this disclaimer belongs to PetJoy. The platform has the right to modify the content of this statement at any time based on actual circumstances, and the modified statement becomes effective once published. Users are advised to pay attention to and comply with the updates.</p>
    <p>PetJoy reserves the right to interpret this disclaimer within the extent permitted by law.</p>

    <p style='text-align: right'>PetJoy Development Team</p>
    <p style='text-align: right'>8 July 2024</p>
  </el-container>

  <!--西班牙语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'es'">
    <p>Bienvenido a la plataforma PetJoy. Antes de utilizar los servicios ofrecidos por la plataforma PetJoy (en adelante, "la Plataforma"), por favor lea detenidamente y comprenda completamente esta declaración. Usted puede optar por no utilizar la Plataforma, pero si decide utilizarla, su uso se considerará como un reconocimiento de la totalidad del contenido de esta declaración.</p>
    <p>Las exenciones de responsabilidad específicas son las siguientes:</p>

    <h1>Publicación y uso de información</h1>
    <ol>
      <li>Toda la información y recursos proporcionados por la Plataforma, incluyendo pero no limitado a textos, imágenes, material audiovisual, comentarios de usuarios y enlaces de terceros, provienen de Internet, usuarios y socios. La Plataforma se esfuerza por asegurar la precisión y la integridad de la información, pero no garantiza de manera explícita o implícita la autenticidad, precisión, puntualidad, integridad o efectividad de la información.</li>
      <li>El contenido publicado por los usuarios en PetJoy debe cumplir con las leyes y regulaciones nacionales y las normas de la Plataforma, y no debe incluir contenido ilegal, infractor, falso, engañoso, ofensivo u otro contenido inapropiado. La Plataforma tiene derecho a eliminar, bloquear u otros procesamientos de contenido sospechoso de violar las leyes o normativas de la Plataforma, pero no asume ninguna responsabilidad por el contenido publicado por los usuarios.</li>
    </ol>

    <h1>Uso de la información y riesgos</h1>
    <ol>
      <li>Los usuarios deben evaluar y juzgar por sí mismos la información obtenida en PetJoy y asumir todos los riesgos y responsabilidades derivados del uso de dicha información. La Plataforma no asume ninguna responsabilidad por pérdidas directas o indirectas sufridas por los usuarios debido al uso o dependencia de la información proporcionada en la Plataforma.</li>
      <li>Cuando los usuarios interactúan, comercian o se comunican en la Plataforma, deben juzgar cuidadosamente los riesgos relacionados; la Plataforma solo actúa como intermediario para el intercambio de información y no es responsable de ninguna acción o sus resultados.</li>
    </ol>

    <h1>Derechos de propiedad intelectual</h1>
    <ol>
      <li>Todos los contenidos en PetJoy, incluidos pero no limitados a textos, imágenes, audio, video, software, programas y diseño de páginas, son propiedad intelectual de la Plataforma o de los titulares de derechos correspondientes. Sin el permiso escrito de la Plataforma o los titulares de derechos, nadie está autorizado a copiar, redistribuir, transmitir, adaptar, compilar o usar de otro modo el contenido de la Plataforma.</li>
      <li>El contenido publicado por los usuarios en la Plataforma se considera como una licencia otorgada a la Plataforma para usar dicho contenido a nivel mundial de manera gratuita, no exclusiva y sublicenciable, incluyendo su exhibición, promoción y otros usos legales.</li>
    </ol>

    <h1>Protección de la privacidad de los usuarios</h1>
    <ol>
      <li>PetJoy valora la protección de la privacidad de los usuarios y tomará medidas razonables para proteger la seguridad de la información personal de los usuarios. Los usuarios deben proporcionar información personal verdadera y precisa al utilizar los servicios de la Plataforma y son responsables de la autenticidad, legalidad y validez de su información.</li>
      <li>A menos que las leyes o regulaciones especifiquen lo contrario o el usuario acuerde de otro modo, la Plataforma no divulgará, venderá o compartirá la información personal de los usuarios a terceros.</li>
    </ol>

    <h1>Responsabilidad legal</h1>
    <ol>
      <li>Al utilizar PetJoy, los usuarios deben cumplir con las leyes y regulaciones nacionales y las normativas de la Plataforma. Los usuarios asumirán todas las consecuencias derivadas de cualquier violación de estas disposiciones. La Plataforma tiene derecho a tomar medidas como restricción, suspensión o terminación del servicio contra usuarios que violen las normas, y se reserva el derecho de tomar acciones legales.</li>
    </ol>

    <p>Los derechos de interpretación y modificación de esta declaración de exención de responsabilidad pertenecen a PetJoy. La Plataforma tiene derecho a modificar el contenido de esta declaración en cualquier momento; la declaración modificada será efectiva inmediatamente después de su publicación. Los usuarios deben estar atentos y cumplir con la nueva declaración.</p>
    <p>PetJoy se reserva el derecho de interpretar esta declaración en el marco permitido por la ley.</p>

    <p style='text-align: right'>Equipo de Desarrollo de PetJoy</p>
    <p style='text-align: right'>8 de julio de 2024</p>
  </el-container>

  <!--法语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'fr'">
    <p>Bienvenue sur la plateforme PetJoy. Avant d'utiliser les services de la plateforme PetJoy (ci-après "la Plateforme"), veuillez lire attentivement et comprendre intégralement cette déclaration. Vous pouvez choisir de ne pas utiliser la Plateforme, mais si vous décidez de l'utiliser, votre utilisation sera considérée comme une reconnaissance du contenu intégral de cette déclaration.</p>
    <p>Les décharges de responsabilité spécifiques sont les suivantes :</p>

    <h1>Publication et utilisation des informations</h1>
    <ol>
      <li>Toutes les informations et ressources fournies par la Plateforme, y compris mais sans s'y limiter, les textes, images, matériaux audiovisuels, commentaires des utilisateurs et liens tiers, proviennent d'Internet, des utilisateurs et des partenaires. La Plateforme s'efforce de garantir l'exactitude et l'intégralité des informations, mais ne garantit pas expressément ou implicitement l'authenticité, l'exactitude, la ponctualité, la complétude ou l'efficacité des informations.</li>
      <li>Le contenu publié par les utilisateurs sur PetJoy doit être conforme aux lois et règlements nationaux ainsi qu'aux règles de la Plateforme, et ne doit pas inclure de contenu illégal, en violation de droits, faux, trompeur, offensant ou autrement inapproprié. La Plateforme a le droit de supprimer, bloquer ou traiter autrement le contenu suspecté de violer les lois ou les règlements de la Plateforme, mais ne assume aucune responsabilité pour le contenu publié par les utilisateurs.</li>
    </ol>

    <h1>Utilisation des informations et risques</h1>
    <ol>
      <li>Les utilisateurs doivent évaluer et juger eux-mêmes les informations obtenues sur PetJoy et assumer tous les risques et responsabilités découlant de l'utilisation de ces informations. La Plateforme ne peut être tenue responsable des pertes directes ou indirectes subies par les utilisateurs du fait de l'utilisation ou de la dépendance aux informations fournies sur la Plateforme.</li>
      <li>Lorsque les utilisateurs interagissent, effectuent des transactions ou communiquent sur la Plateforme, ils doivent évaluer prudemment les risques associés ; la Plateforme agit uniquement en tant qu'intermédiaire pour l'échange d'informations et n'est pas responsable des actions ou de leurs résultats.</li>
    </ol>

    <h1>Droits de propriété intellectuelle</h1>
    <ol>
      <li>Tous les contenus sur PetJoy, y compris mais non limités à des textes, images, audio, vidéo, logiciels, programmes et design de page, sont la propriété intellectuelle de la Plateforme ou de leurs détenteurs de droits respectifs. Sans l'autorisation écrite de la Plateforme ou des détenteurs de droits, personne n'est autorisé à copier, redistribuer, transmettre, adapter, compiler ou utiliser de quelque manière que ce soit le contenu de la Plateforme.</li>
      <li>Le contenu publié par les utilisateurs sur la Plateforme est considéré comme accordant à la Plateforme une licence gratuite, non exclusive et pouvant être sous-licenciée, à l'échelle mondiale, pour utiliser ce contenu, y compris pour l'affichage, la promotion et d'autres usages légaux.</li>
    </ol>

    <h1>Protection de la vie privée des utilisateurs</h1>
    <ol>
      <li>PetJoy accorde une grande importance à la protection de la vie privée des utilisateurs et prendra des mesures raisonnables pour protéger la sécurité des informations personnelles des utilisateurs. Les utilisateurs doivent fournir des informations personnelles véritables et précises lors de l'utilisation des services de la Plateforme et sont responsables de l'authenticité, de la légalité et de la validité de leurs informations.</li>
      <li>Sauf disposition contraire de la loi ou accord de l'utilisateur, la Plateforme ne divulguera, ne vendra ni ne partagera les informations personnelles des utilisateurs à des tiers.</li>
    </ol>

    <h1>Responsabilité légale</h1>
    <ol>
      <li>Lors de l'utilisation de PetJoy, les utilisateurs doivent respecter les lois et règlements nationaux ainsi que les règlements de la Plateforme. Les utilisateurs assument toutes les conséquences résultant d'une violation de ces dispositions. La Plateforme a le droit de prendre des mesures telles que la restriction, la suspension ou la terminaison du service contre les utilisateurs en violation, et se réserve le droit de poursuivre en justice.</li>
    </ol>

    <p>Les droits d'interprétation et de modification de cette déclaration de non-responsabilité appartiennent à PetJoy. La Plateforme a le droit de modifier le contenu de cette déclaration à tout moment ; la déclaration modifiée prend effet immédiatement après sa publication. Les utilisateurs doivent être attentifs et se conformer à la nouvelle déclaration.</p>
    <p>PetJoy se réserve le droit d'interpréter cette déclaration dans le cadre autorisé par la loi.</p>

    <p style='text-align: right'>Équipe de Développement PetJoy</p>
    <p style='text-align: right'>8 juillet 2024</p>
  </el-container>

  <!--意大利语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'it'">
    <p>Benvenuti sulla piattaforma PetJoy. Prima di utilizzare i servizi offerti dalla piattaforma PetJoy (di seguito "la Piattaforma"), si prega di leggere attentamente e comprendere completamente questa dichiarazione. Potete scegliere di non utilizzare la Piattaforma, ma se decidete di farlo, il vostro utilizzo sarà considerato come un riconoscimento del contenuto completo di questa dichiarazione.</p>
    <p>Le specifiche esclusioni di responsabilità sono le seguenti:</p>

    <h1>Pubblicazione e utilizzo delle informazioni</h1>
    <ol>
      <li>Tutte le informazioni e le risorse fornite dalla Piattaforma, inclusi ma non limitati a testi, immagini, materiale audiovisivo, commenti degli utenti e link a terzi, provengono da Internet, dagli utenti e dai partner. La Piattaforma si impegna a garantire l'accuratezza e l'integrità delle informazioni, ma non garantisce espressamente o implicitamente l'autenticità, l'accuratezza, la tempestività, la completezza o l'efficacia delle informazioni.</li>
      <li>I contenuti pubblicati dagli utenti su PetJoy devono rispettare le leggi e i regolamenti nazionali e le norme della Piattaforma, e non devono includere contenuti illegali, lesivi dei diritti, falsi, fuorvianti, offensivi o altrimenti inappropriati. La Piattaforma ha il diritto di eliminare, bloccare o trattare in altro modo i contenuti che si sospetta violino le leggi o i regolamenti della Piattaforma, ma non assume alcuna responsabilità per i contenuti pubblicati dagli utenti.</li>
    </ol>

    <h1>Utilizzo delle informazioni e rischi</h1>
    <ol>
      <li>Gli utenti devono valutare e giudicare personalmente le informazioni ottenute su PetJoy e assumersi tutti i rischi e le responsabilità derivanti dall'uso di tali informazioni. La Piattaforma non assume alcuna responsabilità per le perdite dirette o indirette subite dagli utenti a causa dell'uso o della dipendenza dalle informazioni fornite sulla Piattaforma.</li>
      <li>Quando gli utenti interagiscono, commerciano o comunicano sulla Piattaforma, devono valutare con attenzione i rischi correlati; la Piattaforma agisce solo come intermediario per lo scambio di informazioni e non è responsabile di alcuna azione o dei suoi risultati.</li>
    </ol>

    <h1>Diritti di proprietà intellettuale</h1>
    <ol>
      <li>Tutti i contenuti su PetJoy, inclusi ma non limitati a testi, immagini, audio, video, software, programmi e design delle pagine, sono di proprietà intellettuale della Piattaforma o dei rispettivi titolari dei diritti. Senza l'autorizzazione scritta della Piattaforma o dei titolari dei diritti, nessuno è autorizzato a copiare, redistribuire, trasmettere, adattare, compilare o utilizzare in altro modo il contenuto della Piattaforma.</li>
      <li>I contenuti pubblicati dagli utenti sulla Piattaforma sono considerati come una concessione alla Piattaforma di un diritto e licenza globale, gratuito, non esclusivo e sublicenziabile per utilizzare tali contenuti, inclusi la visualizzazione, la promozione e altri usi legali.</li>
    </ol>

    <h1>Protezione della privacy degli utenti</h1>
    <ol>
      <li>PetJoy attribuisce grande importanza alla protezione della privacy degli utenti e adotterà misure ragionevoli per proteggere la sicurezza delle informazioni personali degli utenti. Gli utenti devono fornire informazioni personali vere e accurate quando utilizzano i servizi della Piattaforma e sono responsabili dell'autenticità, della legalità e della validità delle loro informazioni.</li>
      <li>A meno che non sia diversamente specificato dalle leggi o dai regolamenti, o concordato diversamente dall'utente, la Piattaforma non rivelerà, venderà o condividerà le informazioni personali degli utenti a terzi.</li>
    </ol>

    <h1>Responsabilità legale</h1>
    <ol>
      <li>Quando utilizzano PetJoy, gli utenti devono rispettare le leggi e i regolamenti nazionali nonché le norme della Piattaforma. Gli utenti si assumono tutte le conseguenze derivanti da eventuali violazioni di tali disposizioni. La Piattaforma ha il diritto di prendere misure come la restrizione, la sospensione o la terminazione del servizio contro gli utenti che violano le regole, e si riserva il diritto di intraprendere azioni legali.</li>
    </ol>

    <p>I diritti di interpretazione e di modifica di questa dichiarazione di non responsabilità appartengono a PetJoy. La Piattaforma ha il diritto di modificare il contenuto di questa dichiarazione in qualsiasi momento; la dichiarazione modificata diventa efficace immediatamente dopo la sua pubblicazione. Gli utenti dovrebbero prestare attenzione e rispettare la nuova dichiarazione.</p>
    <p>PetJoy si riserva il diritto di interpretare questa dichiarazione nei limiti consentiti dalla legge.</p>

    <p style='text-align: right'>Team di Sviluppo PetJoy</p>
    <p style='text-align: right'>8 luglio 2024</p>
  </el-container>

  <!--日语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ja'">
    <p>PetJoy プラットフォームへようこそ。PetJoy プラットフォーム（以下、「本プラットフォーム」と称します）の各サービスをご利用になる前に、この声明を注意深くお読みになり、完全に理解してください。本プラットフォームを利用しない選択も可能ですが、本プラットフォームを利用した場合、その行為はこの声明の全内容に同意したと見なされます。</p>
    <p>具体的な免責事項は以下の通りです：</p>

    <h1>情報の公開および利用</h1>
    <ol>
      <li>本プラットフォームが提供するすべての情報およびリソース（テキスト、画像、音声・映像資料、ユーザーコメント、第三者リンクを含むがこれに限らない）は、インターネット、ユーザー、パートナーからのものです。本プラットフォームは情報の正確性と完全性を保証するよう努めていますが、情報の真実性、正確性、タイムリネス、完全性、および有効性について、明示的または暗示的な保証はいたしません。</li>
      <li>ユーザーが PetJoy に投稿するコンテンツは、国の法律や規制、プラットフォームの規則に適合するものでなければならず、違法、権利侵害、虚偽、誤解を招く、侮辱的、または不適切な内容を投稿してはなりません。本プラットフォームは、法律や規則に違反する可能性のあるコンテンツを削除、ブロック、またはその他の処理を行う権利を有しますが、ユーザーが投稿したコンテンツに対して責任を負いません。</li>
    </ol>

    <h1>情報の利用とリスク</h1>
    <ol>
      <li>ユーザーは、PetJoy で取得した情報を自身で判断し、その情報の利用によって生じるリスクと責任を自己負担する必要があります。本プラットフォームは、プラットフォーム上の情報の利用または依存によって生じるユーザーの直接的または間接的な損失について、責任を負いません。</li>
      <li>ユーザーが本プラットフォーム上でコミュニケーション、取引、相互作用を行う際には、関連するリスクを慎重に判断する必要があります。プラットフォームは情報交換の仲介者としてのみ機能し、いかなる取引行為およびその結果に対しても責任を負いません。</li>
    </ol>

    <h1>知的財産権</h1>
    <ol>
      <li>PetJoy に掲載されているすべてのコンテンツ（テキスト、画像、音声、動画、ソフトウェア、プログラム、ページデザインなどを含むがこれに限らない）の知的財産権は、本プラットフォームまたは関連する権利所有者に帰属します。プラットフォームまたは権利所有者の書面による許可なく、誰もが本プラットフォームのコンテンツを無断で複製、再配布、伝播、改変、集約、その他の方法で使用することはできません。</li>
      <li>プラットフォーム上でユーザーにより公開されたコンテンツは、プラットフォームがそのコンテンツを全世界的に無料で非独占的に再許諾可能な権利およびライセンスを有するものと見なされ、展示、促進、その他の合法的な方法でそのコンテンツを使用することを許可します。</li>
    </ol>

    <h1>ユーザーのプライバシー保護</h1>
    <ol>
      <li>PetJoy はユーザーのプライバシーの保護を重視し、ユーザーの個人情報の安全を保護するための合理的な措置を講じます。ユーザーは、プラットフォームサービスを利用する際に、真実かつ正確な個人情報を提供する必要があり、その情報の真実性、合法性、有効性を保証する責任を負います。</li>
      <li>法律または規制に特別な規定がある場合やユーザーが別途同意した場合を除き、本プラットフォームは第三者にユーザーの個人情報を開示、販売、共有することはありません。</li>
    </ol>

    <h1>法的責任</h1>
    <ol>
      <li>ユーザーは、PetJoy を使用する際、国家の法律および規制およびプラットフォームの規則を遵守し、関連規定に違反したことによって生じるすべての結果を自己負担します。本プラットフォームは、実際の状況に基づいて違反ユーザーに対してサービスの制限、一時停止、または終了の措置を取る権利を有し、法的責任を追求する権利を保留します。</li>
    </ol>

    <p>この免責事項の解釈権および変更権は PetJoy に帰属します。プラットフォームは実際の状況に応じて、この声明の内容を随時変更する権利を有し、変更後の声明は公表されるとすぐに効力を発生しますので、ユーザーはタイムリーに注意し、遵守する必要があります。</p>
    <p>PetJoy は法的に許される範囲内で、この声明の最終的な解釈権を保有します。</p>

    <p style='text-align: right'>PetJoy 開発チーム</p>
    <p style='text-align: right'>2024 年 7 月 8 日</p>
  </el-container>

  <!--韩语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ko'">
    <p>PetJoy 플랫폼에 오신 것을 환영합니다. PetJoy 플랫폼(이하 '본 플랫폼')에서 제공하는 서비스를 이용하기 전에, 본 선언을 주의 깊게 읽고 철저히 이해해 주시기 바랍니다. 귀하께서는 본 플랫폼을 이용하지 않을 선택을 할 수 있습니다만, 본 플랫폼을 이용할 경우 귀하의 사용 행위는 본 선언의 모든 내용에 대한 동의로 간주됩니다.</p>
    <p>구체적인 면책 조항은 다음과 같습니다:</p>

    <h1>정보 게시 및 사용</h1>
    <ol>
      <li>본 플랫폼이 제공하는 모든 정보와 자원(텍스트, 이미지, 오디오 및 비디오 자료, 사용자 코멘트, 제3자 링크를 포함하나 이에 국한되지 않음)은 인터넷, 사용자 및 파트너로부터 제공됩니다. 본 플랫폼은 정보의 정확성과 완전성을 보장하기 위해 노력하지만, 정보의 진실성, 정확성, 시의성, 완전성 및 유효성에 대해 명시적이거나 묵시적인 보증을 제공하지 않습니다.</li>
      <li>사용자가 PetJoy 에 게시하는 콘텐츠는 국가 관련 법률 및 규정과 플랫폼 규칙을 준수해야 하며, 불법, 권리 침해, 허위, 오도, 모욕적 또는 기타 부적절한 내용을 게시해서는 안 됩니다. 본 플랫폼은 법률 또는 플랫폼 규정을 위반할 가능성이 있는 콘텐츠를 삭제, 차단 또는 기타 처리할 권리를 가지고 있으며, 사용자가 게시한 콘텐츠에 대해 어떠한 책임도 지지 않습니다.</li>
    </ol>

    <h1>정보 사용 및 위험</h1>
    <ol>
      <li>사용자는 PetJoy 에서 획득한 정보를 스스로 판단하고, 해당 정보 사용으로 인해 발생하는 위험과 책임을 스스로 부담해야 합니다. 본 플랫폼은 플랫폼에서 제공하는 정보를 사용하거나 의존함으로써 발생하는 사용자의 직접적 또는 간접적 손실에 대해 책임을 지지 않습니다.</li>
      <li>사용자가 본 플랫폼에서 커뮤니케이션, 거래, 상호 작용을 할 때, 관련 위험을 신중히 판단해야 합니다. 플랫폼은 정보 교환의 중개자로서만 기능하며, 어떠한 거래 행위 및 그 결과에 대해서도 책임을 지지 않습니다.</li>
    </ol>

    <h1>지적 재산권</h1>
    <ol>
      <li>PetJoy 에 게시된 모든 콘텐츠(텍스트, 이미지, 오디오, 비디오, 소프트웨어, 프로그램, 페이지 디자인 등을 포함하나 이에 국한되지 않음)의 지적 재산권은 본 플랫폼 또는 관련 권리자에게 속합니다. 플랫폼 또는 권리자의 서면 허가 없이는 누구도 본 플랫폼의 콘텐츠를 임의로 복사, 재배포, 전송, 변경, 집합 또는 기타 방법으로 사용할 수 없습니다.</li>
      <li>플랫폼에서 사용자가 게시한 콘텐츠는 사용자가 플랫폼에 전 세계적으로 무료, 비독점적, 재라이선스 가능한 권리 및 허가를 부여한 것으로 간주되며, 플랫폼은 그 콘텐츠를 전시, 홍보 및 기타 합법적 방법으로 사용할 수 있습니다.</li>
    </ol>

    <h1>사용자 개인 정보 보호</h1>
    <ol>
      <li>PetJoy 는 사용자의 개인 정보 보호를 중시하며, 사용자의 개인 정보 보안을 보호하기 위한 합리적 조치를 취합니다. 사용자는 플랫폼 서비스를 이용할 때 진실되고 정확한 개인 정보를 제공해야 하며, 그 정보의 진실성, 합법성, 유효성에 대한 책임을 집니다.</li>
      <li>법률이나 규정에 다른 규정이 있거나 사용자가 별도로 동의한 경우를 제외하고, 본 플랫폼은 사용자의 개인 정보를 제3자에게 공개, 판매 또는 공유하지 않습니다.</li>
    </ol>

    <h1>법적 책임</h1>
    <ol>
      <li>PetJoy 를 사용하는 사용자는 국가 법률 및 규정 및 플랫폼 규칙을 준수해야 하며, 관련 규정을 위반하여 발생하는 모든 결과에 대해 스스로 책임을 집니다. 본 플랫폼은 위반 사용자에 대해 서비스 제한, 일시 정지 또는 종료 조치를 취할 권리를 가지며, 법적 책임을 추구할 권리를 보유합니다.</li>
    </ol>

    <p>이免責事項의 해석권 및 변경권은 PetJoy 에 있습니다. 플랫폼은 현실에 맞추어 이 선언의 내용을 언제든지 변경할 권리가 있으며, 변경된 선언은 발표 즉시 효력을 발생합니다. 사용자는 이를 주의 깊게 확인하고 준수해야 합니다.</p>
    <p>PetJoy 는 법적으로 허용되는 범위 내에서 이 선언의 최종 해석권을 보유합니다.</p>

    <p style='text-align: right'>PetJoy 개발 팀</p>
    <p style='text-align: right'>2024 년 7 월 8 일</p>
  </el-container>

  <!--葡萄牙语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'pt'">
    <p>Bem-vindo à plataforma PetJoy. Antes de utilizar os serviços oferecidos pela plataforma PetJoy (doravante referida como "a Plataforma"), por favor, leia e compreenda completamente esta declaração. Você pode optar por não usar a Plataforma, mas se escolher utilizá-la, seu uso será considerado como aceitação de todo o conteúdo desta declaração.</p>
    <p>As isenções de responsabilidade específicas são as seguintes:</p>

    <h1>Publicação e uso de informações</h1>
    <ol>
      <li>Todas as informações e recursos fornecidos pela Plataforma, incluindo mas não limitados a textos, imagens, materiais audiovisuais, comentários de usuários e links de terceiros, são provenientes da internet, usuários e parceiros. A Plataforma esforça-se para garantir a precisão e integridade das informações, mas não oferece nenhuma garantia, explícita ou implícita, quanto à veracidade, precisão, pontualidade, completude ou eficácia das informações.</li>
      <li>Os conteúdos publicados pelos usuários na PetJoy devem cumprir as leis e regulamentos nacionais e as regras da Plataforma, e não devem incluir conteúdo ilegal, infrator, falso, enganoso, ofensivo ou de qualquer outra forma inapropriado. A Plataforma tem o direito de remover, bloquear ou tratar de outra forma conteúdos que suspeitem violar as leis ou regulamentos da Plataforma, mas não assume qualquer responsabilidade pelo conteúdo publicado pelos usuários.</li>
    </ol>

    <h1>Uso das informações e riscos</h1>
    <ol>
      <li>Os usuários devem avaliar e julgar por si mesmos as informações obtidas na PetJoy e assumir todos os riscos e responsabilidades decorrentes do uso dessas informações. A Plataforma não assume qualquer responsabilidade por perdas diretas ou indiretas sofridas pelos usuários devido ao uso ou dependência das informações fornecidas na Plataforma.</li>
      <li>Quando os usuários realizam interações, transações ou comunicações na Plataforma, devem julgar cuidadosamente os riscos associados; a Plataforma serve apenas como intermediária para a troca de informações e não é responsável por qualquer ação ou seus resultados.</li>
    </ol>

    <h1>Direitos de propriedade intelectual</h1>
    <ol>
      <li>Todos os conteúdos da PetJoy, incluindo mas não limitados a textos, imagens, áudio, vídeo, software, programas e design de páginas, são de propriedade intelectual da Plataforma ou dos respectivos titulares de direitos. Sem a permissão por escrito da Plataforma ou dos titulares dos direitos, ninguém está autorizado a copiar, redistribuir, transmitir, adaptar, compilar ou utilizar de outra forma o conteúdo da Plataforma.</li>
      <li>O conteúdo publicado pelos usuários na Plataforma é considerado como concedendo à Plataforma uma licença global, gratuita, não exclusiva e sublicenciável para usar esse conteúdo, incluindo para exibição, promoção e outros usos legais.</li>
    </ol>

    <h1>Proteção da privacidade dos usuários</h1>
    <ol>
      <li>A PetJoy valoriza a proteção da privacidade dos usuários e tomará medidas razoáveis para proteger a segurança das informações pessoais dos usuários. Os usuários devem fornecer informações pessoais verdadeiras e precisas ao usar os serviços da Plataforma e são responsáveis pela veracidade, legalidade e validade de suas informações.</li>
      <li>A menos que a lei ou regulamento especifique o contrário ou o usuário concorde de outra forma, a Plataforma não divulgará, venderá ou compartilhará as informações pessoais dos usuários com terceiros.</li>
    </ol>

    <h1>Responsabilidade legal</h1>
    <ol>
      <li>Ao usar a PetJoy, os usuários devem cumprir as leis e regulamentos nacionais, bem como as regras da Plataforma. Os usuários assumirão todas as consequências decorrentes de qualquer violação dessas disposições. A Plataforma tem o direito de tomar medidas como restrição, suspensão ou término do serviço contra usuários que violem as regras, e reserva-se o direito de buscar responsabilidade legal.</li>
    </ol>

    <p>Os direitos de interpretação e modificação desta declaração de isenção de responsabilidade pertencem à PetJoy. A Plataforma tem o direito de modificar o conteúdo desta declaração a qualquer momento; a declaração modificada torna-se efetiva imediatamente após sua publicação. Os usuários devem prestar atenção e cumprir a declaração atualizada.</p>
    <p>A PetJoy reserva-se o direito de interpretar esta declaração dentro dos limites permitidos por lei.</p>

    <p style='text-align: right'>Equipe de Desenvolvimento PetJoy</p>
    <p style='text-align: right'>8 de julho de 2024</p>
  </el-container>

  <!--俄语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ru'">
    <p>Добро пожаловать на платформу PetJoy. Перед тем как начать использовать сервисы, предоставляемые платформой PetJoy (далее "Платформа"), пожалуйста, внимательно прочитайте и полностью поймите это заявление. Вы можете выбрать не использовать Платформу, но если вы решите её использовать, ваше использование будет считаться признанием всего содержания данного заявления.</p>
    <p>Конкретные условия отказа от ответственности следующие:</p>

    <h1>Публикация и использование информации</h1>
    <ol>
      <li>Вся информация и ресурсы, предоставляемые Платформой, включая, но не ограничиваясь текстами, изображениями, аудио и видео материалами, комментариями пользователей и ссылками третьих сторон, поступают из интернета, от пользователей и партнёров. Платформа стремится обеспечить точность и полноту информации, но не дает никаких явных или подразумеваемых гарантий достоверности, точности, своевременности, полноты или эффективности информации.</li>
      <li>Контент, размещаемый пользователями на PetJoy, должен соответствовать национальным законам и регуляциям, а также правилам Платформы, и не должен содержать незаконные, нарушающие права, ложные, вводящие в заблуждение, оскорбительные или иные неподобающие материалы. Платформа имеет право удалять, блокировать или обрабатывать контент, который подозревается в нарушении законов или правил Платформы, но не несет ответственности за контент, размещенный пользователями.</li>
    </ol>

    <h1>Использование информации и риски</h1>
    <ol>
      <li>Пользователи должны самостоятельно оценивать и анализировать информацию, полученную на PetJoy, и нести все риски и ответственность, связанные с использованием этой информации. Платформа не несет ответственности за любые прямые или косвенные убытки, понесенные пользователями в результате использования или зависимости от информации, предоставленной на Платформе.</li>
      <li>При взаимодействии, совершении сделок или общении на Платформе пользователи должны самостоятельно оценивать связанные с этим риски; Платформа выступает только в качестве посредника для обмена информацией и не несет ответственности за какие-либо действия или их результаты.</li>
    </ol>

    <h1>Интеллектуальная собственность</h1>
    <ol>
      <li>Все материалы на PetJoy, включая, но не ограничиваясь текстами, изображениями, аудио, видео, программным обеспечением, программами и дизайном страниц, являются объектами интеллектуальной собственности Платформы или соответствующих правообладателей. Без письменного разрешения Платформы или правообладателей никто не имеет права копировать, распространять, передавать, адаптировать, компилировать или иным образом использовать контент Платформы.</li>
      <li>Контент, размещенный пользователями на Платформе, считается предоставлением Платформе глобального, бесплатного, неисключительного и передаваемого права и лицензии на использование этого контента, включая демонстрацию, продвижение и другие законные способы использования.</li>
    </ol>

    <h1>Защита конфиденциальности пользователей</h1>
    <ol>
      <li>PetJoy серьезно относится к защите конфиденциальности пользователей и примет разумные меры для защиты безопасности личной информации пользователей. Пользователи, использующие сервисы Платформы, должны предоставлять достоверную и точную личную информацию, и несут ответственность за достоверность, законность и актуальность своих данных.</li>
      <li>Если иное не предусмотрено законом или регуляциями или пользователь не дал иного согласия, Платформа не будет раскрывать, продавать или делиться личной информацией пользователей с третьими лицами.</li>
    </ol>

    <h1>Юридическая ответственность</h1>
    <ol>
      <li>Пользователи, использующие PetJoy, должны соблюдать национальные законы и регуляции, а также правила Платформы. Все последствия нарушения соответствующих положений ложатся на пользователей. Платформа имеет право принимать меры, такие как ограничение, приостановка или прекращение обслуживания в отношении пользователей, нарушающих правила, и оставляет за собой право на юридическое преследование.</li>
    </ol>

    <p>Право на толкование и изменение данного отказа от ответственности принадлежит PetJoy. Платформа имеет право в любое время изменять содержание этого заявления; измененное заявление вступает в силу немедленно после публикации. Пользователи должны внимательно следить и соблюдать его.</p>
    <p>PetJoy оставляет за собой право на окончательное толкование этого заявления в пределах, разрешенных законом.</p>

    <p style='text-align: right'>Команда разработчиков PetJoy</p>
    <p style='text-align: right'>8 июля 2024 года</p>
  </el-container>

  <!--汉语（默认语言）版本-->
  <el-container direction='vertical' v-else>
    <p>欢迎您访问宠悦（PetJoy）平台。在使用宠悦（PetJoy）平台（以下简称“本平台”）提供的各项服务前，请您务必仔细阅读并透彻理解本声明。您可以选择不使用本平台，但如果您使用本平台，您的使用行为将被视为对本声明全部内容的认可。</p>
    <p>具体免责声明如下：</p>

    <h1>信息发布及使用</h1>
    <ol>
      <li>本平台所提供的所有信息及资源，包括但不限于文字、图片、音视频资料、用户评论及第三方链接，均来源于互联网、用户及合作伙伴。本平台力求确保信息的准确性和完整性，但不对信息的真实性、准确性、及时性、完整性及有效性作任何明示或暗示的担保。</li>
      <li>用户在宠悦（PetJoy）发布的内容应符合国家相关法律法规及平台规定，不得发布违法、侵权、虚假、误导性、侮辱性或其他不适当的内容。本平台有权对涉嫌违反法律法规或平台规定的内容进行删除、屏蔽或其他处理，但不对用户发布内容承担任何责任。</li>
    </ol>

    <h1>信息的使用及风险</h1>
    <ol>
      <li>用户应对在宠悦（PetJoy）上获取的信息自行甄别和判断，并自行承担因使用该信息而导致的风险和责任。本平台不对用户因使用或依赖平台上的信息而导致的任何直接或间接损失承担责任。</li>
      <li>用户在本平台进行交流、交易、互动时，应自行审慎判断相关风险，平台仅作为信息交流的中介，不对任何交易行为及其结果负责。</li>
    </ol>

    <h1>知识产权</h1>
    <ol>
      <li>宠悦（PetJoy）上的所有内容（包括但不限于文字、图片、音频、视频、软件、程序、页面设计等）的知识产权归本平台或相关权利人所有。未经平台或权利人书面许可，任何人不得擅自复制、转载、传播、改编、汇编或以其他方式使用本平台的内容。</li>
      <li>用户在平台发布的内容，视为用户授予平台在全球范围内的免费、非独占、可再许可的权利和许可，允许平台以展示、推广和其他合法方式使用该内容。</li>
    </ol>

    <h1>用户隐私保护</h1>
    <ol>
      <li>宠悦（PetJoy）重视用户隐私保护，将采取合理措施保护用户的个人信息安全。用户在使用平台服务时，需提供真实、准确的个人信息，并对其信息的真实性、合法性和有效性负责。</li>
      <li>除非法律法规另有规定或用户另行同意，本平台不会向第三方披露、出售或共享用户的个人信息。</li>
    </ol>

    <h1>法律责任</h1>
    <ol>
      <li>用户在使用宠悦（PetJoy）时，应遵守国家法律法规及平台规定，因违反相关规定导致的一切后果由用户自行承担。本平台有权根据实际情况对违规用户采取限制、暂停或终止服务的措施，并保留追究法律责任的权利。</li>
    </ol>

    <p>本免责声明的解释权及修改权归宠悦（PetJoy）所有。平台有权根据实际情况随时修改本声明内容，修改后的声明一经发布即生效，请用户及时关注并遵守。</p>
    <p>宠悦（PetJoy）保留在法律允许的范围内对本声明的最终解释权。</p>

    <p style='text-align: right'>宠悦 | PetJoy 项目开发组</p>
    <p style='text-align: right'>2024 年 7 月 8 日</p>
  </el-container>
</template>

<style scoped>
@import '../styles/FooterNavbarTextCSS.css';
</style>
