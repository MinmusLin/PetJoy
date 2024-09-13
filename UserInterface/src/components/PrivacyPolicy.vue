<!--
  Project Name:  UserInterface
  File Name:     PrivacyPolicy.vue
  File Function: 隐私政策组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-26
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <!--德语版本-->
  <el-container direction='vertical' v-if="$i18n.locale == 'de'">
    <p>PetJoy Projektentwicklungsteam (im Folgenden "Entwicklungsteam", "wir" und "unser") ist sich der Bedeutung Ihrer Privatsphäre bewusst und respektiert diese. Bitte lesen und verstehen Sie diese Datenschutzerklärung (im Folgenden "diese Erklärung"), bevor Sie uns Ihre persönlichen Daten zur Verfügung stellen. Diese Erklärung gilt für Websites und Produkte oder Dienstleistungen, die diese Datenschutzerklärung anzeigen oder auf diese Datenschutzerklärung verlinken. Insbesondere wird diese Website vom Entwicklungsteam betrieben, das für die Verarbeitung der auf dieser Website gesammelten persönlichen Daten verantwortlich ist.</p>

    <h1>Datenerfassung</h1>
    <p>Wie wir Ihre persönlichen Daten erfassen und verwenden:</p>
    <ol>
      <li>Von Ihnen bereitgestellte Informationen: Beim Registrieren eines Kontos, der Teilnahme an Aktivitäten, der Nutzung von Dienstleistungen oder der Kommunikation mit uns müssen Sie möglicherweise Ihren Namen, Kontaktinformationen, E-Mail-Adresse usw. angeben.</li>
      <li>Automatisch gesammelte Informationen: Während der Nutzung unserer Dienstleistungen können wir automatisch Ihre Geräteinformationen, Protokolldaten, Standortinformationen usw. erfassen, um unsere Dienstleistungen bereitzustellen und zu optimieren.</li>
      <li>Daten von Dritten: Wir können Daten von Partnern oder öffentlich zugänglichen Quellen erhalten.</li>
    </ol>

    <h1>Datennutzung</h1>
    <p>Wir können die gesammelten Daten verwenden für:</p>
    <ol>
      <li>Kontenerstellung. Kunden, die an den Dienstleistungen dieser Website interessiert sind, können ein PetJoy-Konto erstellen. Dieses Konto kann Ihnen bei der Nutzung der PetJoy-Dienste zur Authentifizierung, Zugriffsverwaltung und zum Schutz der Sicherheit von Produkten und Dienstleistungen dienen; mit Ihnen in Kontakt treten, Ihnen wichtige Benachrichtigungen senden usw. Zur Erstellung des Kontos erfassen wir die von Ihnen bereitgestellten persönlichen Daten, einschließlich Ihres Namens, Kontos, Passworts, E-Mail, Telefonnummer, Landes oder Region.</li>
      <li>Antwort auf Ihre Interaktionsanforderungen. Wenn Sie unsere Website besuchen, an Online- oder Offline-Aktivitäten teilnehmen, Änderungen verlangen oder die von Ihnen angeforderten Informationen (wie Marketingmaterialien, Whitepapers, Abonnements für elektronische Magazine) anfordern oder uns zu Fragen oder Produktinformationen kontaktieren (wie technische Unterstützung, Feedback, Vorschläge, Anfragen), erfassen wir Ihre folgenden Informationen:
        <ul>
          <li>Kontaktinformationen: Von Ihnen bereitgestellter Name, E-Mail, Telefonnummer, Adresse, Firmenname, Position usw., um mit Ihnen zu kommunizieren, z. B. um Ihnen das abonnierte elektronische Magazin zu senden, auf Ihre Anfragen, Meinungen oder Vorschläge zu antworten oder Ihnen Veranstaltungsgeschenke zuzusenden;</li>
          <li>Interaktionsaufzeichnungen: Ihre Informationsanfragen, Anrufe, E-Mails, Online- und Offline-Aktivitätsaufzeichnungen usw., um auf Ihre Anfragen zu reagieren, z. B. Ihnen das abonnierte elektronische Magazin zu senden, Ihre Meinungen, Vorschläge oder Anfragen zu erhalten, Ihnen Veranstaltungsgeschenke zuzusenden usw.</li>
        </ul>
      </li>
      <li>Empfehlung relevanter Inhalte, Produkte oder Dienstleistungen für Sie. Mit Ihrer Zustimmung senden wir Ihnen Informationen zu Produkten und Dienstleistungen, die für Sie von Interesse sein könnten; laden Sie zur Teilnahme an PetJoy-Aktivitäten (einschließlich Werbeaktionen), Marktumfragen oder Zufriedenheitsumfragen ein; oder bieten Ihnen personalisierte Inhalte und Dienstleistungen, wenn Sie Websites, Apps usw. besuchen. Wir erfassen Ihre folgenden Informationen:
        <ul>
          <li>Kontaktinformationen: Von Ihnen bereitgestellter Name, E-Mail, Telefonnummer, Firmenname, Position, Branche usw. zur Kommunikation mit Ihnen, basierend auf Ihrer Zustimmung, um Ihnen relevante Marketinginformationen zu senden, Sie zur Teilnahme an PetJoy-Aktivitäten einzuladen, Ihnen möglicherweise interessante Produkte oder Dienstleistungen vorzuschlagen usw.;</li>
          <li>Interaktionsaufzeichnungen: Ihre Webseiten-Ladezeiten, Video-Wiedergaben, PDF-Downloads, soziale Medien-Teilen usw., um Ihre Interessen an unseren Websites oder Produkten zu verstehen und Ihnen genauere und angemessenere Informationen oder Dienstleistungen bereitzustellen;</li>
          <li>Geräte- und Netzwerkinformationen: Gerätetyp, Gerätename oder Modell, Gerätekennungen, Betriebssystemtyp und -version, Browsertyp und -version, Bildschirmauflösung, Spracheinstellungen, IP-Adresse, Internetdienstanbieter usw., um die Besuche auf unseren Online-Plattformen zu analysieren und zu statistischen Zwecken zusammenzufassen und Ihre Nutzungserfahrung kontinuierlich zu optimieren.</li>
          <li>Wenn Sie solche Informationen nicht mehr erhalten möchten, können Sie sich jederzeit über die SMS-Anweisungen oder andere von uns bereitgestellte Methoden abmelden.</li>
        </ul>
      </li>
      <li>Andere Situationen:
        <ul>
          <li>Fehlerbehebung, wenn Sie sich entscheiden, uns Fehlerdetails zu senden.</li>
          <li>Schutz unserer Produkte, Dienstleistungen und Kunden oder Benutzer, Implementierung und Verbesserung unserer Verlust- und Betrugsbekämpfungsprogramme.</li>
          <li>Einhaltung und Durchsetzung geltender rechtlicher Anforderungen, relevanter Industriestandards oder unserer Richtlinien.</li>
        </ul>
      </li>
    </ol>

    <h1>Datenweitergabe und Offenlegung</h1>
    <p>Wir teilen Ihre persönlichen Daten nur in angemessen notwendigen Fällen. Solche Fälle umfassen:</p>
    <ol>
      <li>Unsere Unternehmensgruppe, um auf Ihre Anfragen zu reagieren. Alle beteiligten Unternehmen der Gruppe dürfen Ihre persönlichen Daten nur gemäß dieser Datenschutzerklärung verwenden.</li>
      <li>Regulierungsbehörden, Justiz- und Strafverfolgungsbehörden sowie andere Dritte zu Sicherheits-, Schutz- oder Rechtszwecken. In einigen Fällen sind wir gesetzlich verpflichtet, Ihre Daten an Behörden offenzulegen, z. B. zur Einhaltung gesetzlicher Verpflichtungen oder Verfahren, zur Durchsetzung unserer Bedingungen, zur Behandlung von Sicherheits- oder Betrugsangelegenheiten oder zum Schutz unserer Benutzer. Zur Einhaltung gültiger rechtlicher Verfahren, wie Vorladungen, Gerichtsbeschlüsse oder Durchsuchungsbefehle, können wir solche Offenlegungen mit oder ohne Ihre Zustimmung vornehmen. In der Regel verbieten die Bestimmungen des rechtlichen Verfahrens, dass wir Sie über solche Offenlegungen informieren. Wenn eine staatliche Stelle keine Vorladung, keinen Gerichtsbeschluss oder keinen Durchsuchungsbefehl vorlegt, können wir Ihre Zustimmung einholen, um Daten gemäß den Anforderungen der staatlichen Stelle offenzulegen. Wir können Ihre Daten auch aus folgenden Gründen offenlegen:
        <ul>
          <li>Durchsetzung unserer Bedingungen und anderer Vereinbarungen, einschließlich der Untersuchung möglicher Verstöße;</li>
          <li>Erkennung, Verhinderung oder anderweitige Behandlung von Sicherheits-, Betrugs- oder technischen Problemen;</li>
          <li>Schutz unserer Rechte, unseres Eigentums oder unserer Sicherheit sowie der unserer Benutzer, Dritter oder der Öffentlichkeit (zum Austausch von Informationen mit anderen Unternehmen und Organisationen zur Betrugsprävention und zur Verringerung von Kreditrisiken, soweit gesetzlich erforderlich oder zulässig).</li>
        </ul>
      </li>
      <li>Dritte bei vollständiger oder teilweiser Übernahme unseres Unternehmens. Wenn einer der folgenden Fälle eintritt, können wir Ihre persönlichen Daten auch an Dritte weitergeben:
        <ul>
          <li>Wir verkaufen, übertragen, fusionieren, konsolidieren oder restrukturieren einen Teil unseres Geschäfts oder fusionieren mit einem anderen Unternehmen, übernehmen ein anderes Unternehmen oder gründen ein Joint Venture, dann können wir Ihre Daten an jeden neuen Eigentümer oder anderen an der Änderung unseres Geschäfts Beteiligten weitergeben;</li>
          <li>Wir verkaufen oder übertragen eines unserer Vermögenswerte, dann können die von uns gehaltenen Informationen zu Ihnen als Teil dieser Vermögenswerte verkauft und an jeden neuen Eigentümer oder anderen an diesem Verkauf oder dieser Übertragung Beteiligten weitergegeben werden.</li>
        </ul>
      </li>
    </ol>

    <h1>Datensicherheit</h1>
    <p>Unabhängig davon, wo Ihre persönlichen Daten gespeichert sind, verpflichten wir uns, deren Privatsphäre und Integrität zu wahren. Unsere Informationssicherheits- und Zugriffsrichtlinien beschränken den Zugriff auf unsere Systeme und Technologien. Wir schützen Daten durch technische Schutzmaßnahmen wie Verschlüsselung.</p>
    <p>Leider ist die Datenübertragung über das Internet nicht völlig sicher, obwohl wir angemessene Maßnahmen zum Schutz Ihrer persönlichen Daten ergriffen und aufrechterhalten haben. Im Falle eines Sicherheitsvorfalls, wie z. B. eines Datenlecks, werden wir einen Notfallplan einleiten, um die Ausweitung des Sicherheitsvorfalls zu verhindern und Sie durch Benachrichtigungen, Ankündigungen usw. zu informieren.</p>

    <h1>Ihre Rechte</h1>
    <ol>
      <li>Zugriff, Berichtigung, Löschung: Sie können auf Ihre persönlichen Daten zugreifen, diese korrigieren oder deren Löschung verlangen.</li>
      <li>Widerruf der Zustimmung: Sie können jederzeit Ihre zuvor erteilte Zustimmung widerrufen, dies hat jedoch keine Auswirkungen auf die zuvor auf Basis Ihrer Zustimmung erfolgte Verarbeitung Ihrer persönlichen Daten.</li>
      <li>Beschwerde: Sie haben das Recht, sich bei einer Datenschutzbehörde über unsere Datenschutzpraktiken zu beschweren.</li>
    </ol>

    <h1>Kinderinformationen</h1>
    <ol>
      <li>Kinder dürfen diese Website zu keinem Zweck nutzen, es sei denn, ein Elternteil oder Vormund hat zugestimmt. Kinder sind Benutzer unter

        18 Jahren.</li>
      <li>Wir sammeln nicht wissentlich persönliche Daten von Kindern für irgendeinen Zweck. Wenn Sie glauben, dass wir ohne elterliche/gesetzliche Zustimmung persönliche Daten eines Kindes gesammelt haben, oder wenn Sie ein Elternteil oder Vormund sind und Ihre Zustimmung widerrufen möchten, kontaktieren Sie uns bitte, und wir werden solche Informationen löschen.</li>
    </ol>

    <h1>Drittanbieter-Websites und -Dienste</h1>
    <p>Unsere Dienste können Links zu Websites oder Diensten Dritter enthalten (einschließlich Werbung und externer Dienste). Die Verarbeitung Ihrer Daten durch Dritte unterliegt deren Datenschutzerklärung. Wir sind nicht verantwortlich für die Datenschutz- und Datenverarbeitungspraktiken von Dritten.</p>

    <h1>Internationale Datenübertragung</h1>
    <p>Um ein reibungsloses Surferlebnis zu gewährleisten, können Sie Inhalte oder Weblinks von Drittanbietern außerhalb von PetJoy und seinen Partnern erhalten (im Folgenden "Dritte"). Das Entwicklungsteam hat keine Kontrolle über diese Dritten. Sie können wählen, ob Sie die von Dritten bereitgestellten Links, Inhalte, Produkte und Dienstleistungen besuchen möchten.</p>
    <p>Das Entwicklungsteam kann die Datenschutz- und Datenpolitik von Dritten nicht kontrollieren. Diese Dritten unterliegen nicht dieser Erklärung. Bitte lesen Sie die Datenschutzerklärungen dieser Dritten, bevor Sie ihnen persönliche Daten zur Verfügung stellen.</p>

    <h1>Wie Sie uns kontaktieren können</h1>
    <p>Wenn Sie Fragen oder Bedenken zu dieser Erklärung haben, kontaktieren Sie uns bitte.</p>
    <p>Durch die Nutzung der Dienste des Entwicklungsteams erklären Sie sich mit den Bedingungen dieser Datenschutzerklärung einverstanden. Wir verpflichten uns, Ihre persönlichen Daten weiterhin zu schützen und eine sichere und zuverlässige Dienstleistungsumgebung bereitzustellen.</p>

    <p style='text-align: right'>PetJoy Entwicklungsteam</p>
    <p style='text-align: right'>8. Juli 2024</p>
  </el-container>

  <!--英语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'en'">
    <p>The PetJoy development team (hereinafter referred to as "development team," "we," and "our") understands the importance of privacy to you and respects your privacy. Please read and understand this "Privacy Policy" (hereinafter referred to as "this Policy") before submitting personal information to us. This Policy applies to websites and products/services that display or link to this Privacy Policy. In particular, this website is operated by the development team, and the development team is the personal information processor for the personal information collected by this website.</p>

    <h1>Information Collection</h1>
    <p>How we collect and use your personal information:</p>
    <ol>
      <li>Information you provide: You may need to provide information such as your name, contact details, and email address when registering an account, participating in activities, using services, or communicating with us.</li>
      <li>Automatically collected information: During your use of the services, we may automatically collect your device information, log information, location information, etc., to provide and optimize our services.</li>
      <li>Information from third parties: We may receive data shared by partners or publicly available information.</li>
    </ol>

    <h1>Use of Information</h1>
    <p>We may use the collected information for:</p>
    <ol>
      <li>Creating accounts. Customers interested in the services of this website can create a PetJoy account. This account provides identity verification and permission management to protect the security of products and services; contact you and send you important notifications. To create an account, we collect the personal information you provide to us, including your entered name, account, password, email, contact number, country, or region.</li>
      <li>Responding to your interaction requests. When you visit our website, participate in online or offline events, request changes, or request information you asked for (such as marketing materials for products or services, white-papers, magazine subscriptions), and contact us about any issues or product information (such as providing technical support, giving us feedback, inquiries, etc.), we collect the following information:
        <ul>
          <li>Contact information: Your provided name, email, phone, address, company name, position, etc., used to communicate with you, such as sending you the magazine subscriptions you signed up for, responding to your inquiries, feedback, or suggestions, or sending you event gifts, etc.;</li>
          <li>Interaction records: Your information requests, calls, emails, online and offline event records, etc., to respond to your requests, such as sending you the magazine subscriptions you signed up for, obtaining your feedback, suggestions, or inquiries, sending you event gifts, etc.</li>
        </ul>
      </li>
      <li>Recommending related content, products, or services. With your consent, sending you information about products and services you may be interested in; inviting you to participate in PetJoy activities (including promotional activities), market surveys, or satisfaction surveys; or providing personalized content and services when you visit the website, APP, and other online platforms. We collect the following information:
        <ul>
          <li>Contact information: Your provided name, email, phone, company name, position, industry, etc., used to communicate with you, based on your consent, to send you related marketing information, invite you to participate in PetJoy activities, push products or services you may be interested in, etc.;</li>
          <li>Interaction records: Information on your interactions, such as loading web pages, playing videos, downloading PDF files, sharing on social media, etc. To understand your focus points on our website or products, to provide you with more accurate and appropriate information or services;</li>
          <li>Device and network information: Device type, device name or model, device identifier, operating system type and version, browser type and version, screen resolution, language settings, IP address, network service provider, etc., used for aggregated analysis of website, APP, and other online platform visit effects and statistical data, to continuously optimize your user experience.</li>
          <li>If you do not wish to receive such information, you can unsubscribe at any time according to the SMS prompts or other methods we provide.</li>
        </ul>
      </li>
      <li>Other situations:
        <ul>
          <li>In case you choose to send us error details for error investigation.</li>
          <li>Protecting the security of our products, services, and customers or users, implementing and improving our loss prevention and anti-fraud programs.</li>
          <li>Complying with and enforcing applicable legal requirements, relevant industry standards, or our policies.</li>
        </ul>
      </li>
    </ol>

    <h1>Information Sharing and Disclosure</h1>
    <p>We only share your personal information when reasonably necessary. These situations include:</p>
    <ol>
      <li>Companies within our group process your personal information in response to your inquiries. All related group companies can only use your personal information according to this Privacy Policy.</li>
      <li>Regulatory agencies, judicial authorities, and law enforcement agencies, as well as other third parties for security, protection, or compliance with legal purposes. In some cases, we are legally required to disclose your information to authorities, such as complying with legal obligations or procedures, enforcing our terms, dealing with security or fraud-related matters, or protecting our users. To comply with valid legal process terms, such as subpoenas, court orders, or search warrants, we may make these disclosures with or without your consent. Generally, the terms of legal processes prohibit us from notifying you of any such disclosure. If the government entity does not provide the required subpoena, court order, or search warrant, we may seek your consent to disclose information in accordance with the requirements of the government entity. We may also disclose your information for the following purposes:
        <ul>
          <li>Enforcing our terms and conditions and other agreements, including investigating any possible violations of these documents;</li>
          <li>Discovering, preventing, or otherwise addressing security, fraud, or technical issues;</li>
          <li>Protecting the rights, property, or safety of us, our users, third parties, or the public as permitted or required by law (exchanging information with other companies and organizations to prevent fraud and reduce credit risk).</li>
        </ul>
      </li>
      <li>Third parties that acquire all or part of us or our business. If any of the following situations occur, we may also disclose your personal information to third parties:
        <ul>
          <li>If we sell, transfer, merge, consolidate, or reorganize any part of our business, or merge with any other business, acquire any other business, or form a joint venture with it, we may disclose your data to any new owner or other parties involved in our business changes;</li>
          <li>If we sell or transfer any of our assets, the information related to you that we hold may be sold as part of those assets and may be transferred to any new owner or other parties involved in such sale or transfer.</li>
        </ul>
      </li>
    </ol>

    <h1>Information Security</h1>
    <p>No matter where your personal information is stored, we are committed to maintaining its privacy and integrity. Our information security and access policy restrict access to our systems and technology, and we protect data through measures such as encryption.</p>
    <p>Unfortunately, despite implementing and maintaining reasonable measures to protect your personal information, transmitting information over the internet is not entirely secure. In the event of a security incident such as a personal information breach, we will initiate emergency plans to prevent the security incident from expanding and inform you through push notifications, announcements, etc.</p>

    <h1>Your Rights</h1>
    <ol>
      <li>Access, correct, delete: You can access, correct, or request deletion of your personal information.</li>
      <li>Withdraw consent: At any time, you can withdraw the consent you previously gave, but this will not affect the processing of personal information based on your consent before its withdrawal.</li>
      <li>Complaint: You have the right to complain to data protection authorities about our privacy practices.</li>
    </ol>

    <h1>Children's Information</h1>
    <ol>
      <li>Children under the age of 18 are not allowed to use this webpage for any purpose unless consent is provided by a parent or guardian. We refer to children as users under the age of 18.</li>
      <li>We do not intentionally collect personal information from children for any purpose. If you believe that we possess personal information of a child without parental/guardian consent, or if you are the parent or guardian of a user and wish to withdraw consent, please contact us, and we will delete such information.</li>
    </ol>

    <h1>Third-party Websites and Services</h1>
    <p>Our services may contain links to third-party websites or services (including advertisements and external services). The handling of your information by third parties is governed by the privacy policies of those third parties, and we are not responsible for their privacy and data processing practices.</p>

    <h1>International Data Transfers</h1>
    <p>To ensure a smooth browsing experience, you may receive content or web links from PetJoy and its partners, referred to as "third parties" herein. The development team has no control over these third parties. You may choose whether to access links, content, products, and services provided by third parties.</p>
    <p>The development team cannot control the privacy and data protection policies of third parties, and such third parties are not subject to this Policy. Before submitting personal information to third parties, please review their privacy policies.</p>

    <h1>How to Contact Us</h1>
    <p>If you have any questions or concerns about this Policy, please contact us.</p>
    <p>By using the services of the PetJoy development team, you understand and agree to the terms of this Privacy Policy. We are committed to continuously protecting your personal information and providing a secure, reliable service environment.</p>

    <p style='text-align: right'>PetJoy Development Team</p>
    <p style='text-align: right'>8 July 2024</p>
  </el-container>

  <!--西班牙语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'es'">
    <p>El equipo de desarrollo de PetJoy (en adelante, "equipo de desarrollo", "nosotros" y "nuestro") comprende la importancia de su privacidad y respeta su privacidad. Por favor, lea y entienda esta Política de Privacidad (en adelante, "esta política") antes de proporcionarnos su información personal. Esta política se aplica a los sitios web y productos o servicios que muestran esta política de privacidad o que enlazan a esta política de privacidad. En particular, este sitio web es operado por el equipo de desarrollo, que es responsable del procesamiento de la información personal recopilada en este sitio web.</p>

    <h1>Recopilación de información</h1>
    <p>Cómo recopilamos y usamos su información personal:</p>
    <ol>
      <li>Información proporcionada por usted: Al registrar una cuenta, participar en actividades, utilizar servicios o comunicarse con nosotros, es posible que deba proporcionar su nombre, información de contacto, dirección de correo electrónico, etc.</li>
      <li>Información recopilada automáticamente: Durante el uso de nuestros servicios, es posible que recopilemos automáticamente información sobre su dispositivo, información de registros, información de ubicación, etc., para proporcionar y optimizar nuestros servicios.</li>
      <li>Información de terceros: Podemos recibir datos compartidos por socios o información obtenida de fuentes públicas.</li>
    </ol>

    <h1>Uso de la información</h1>
    <p>Podemos utilizar la información recopilada para:</p>
    <ol>
      <li>Crear cuentas. Los clientes interesados en los servicios de este sitio web pueden crear una cuenta de PetJoy. Esta cuenta puede servirle para autenticación, gestión de permisos y protección de la seguridad de productos y servicios durante el uso de los servicios de PetJoy; comunicarse con usted, enviarle notificaciones importantes, etc. Para crear la cuenta, recopilamos la información personal que nos proporciona, incluyendo su nombre, cuenta, contraseña, correo electrónico, número de teléfono, país o región.</li>
      <li>Responder a sus solicitudes de interacción. Cuando visite nuestro sitio web, participe en actividades en línea o fuera de línea, solicite cambios o información que haya solicitado (como materiales de marketing de productos o servicios, libros blancos, suscripciones a revistas electrónicas), y se comunique con nosotros para cualquier pregunta o información de productos (como soporte técnico, comentarios, sugerencias, consultas), recopilamos la siguiente información:
        <ul>
          <li>Información de contacto: Nombre, correo electrónico, teléfono, dirección, nombre de la empresa, cargo, etc., proporcionados por usted para comunicarse con usted, como enviarle la revista electrónica suscrita, responder a sus consultas, opiniones o sugerencias, o enviarle regalos de eventos;</li>
          <li>Registros de interacción: Sus solicitudes de información, llamadas, correos electrónicos, registros de actividades en línea y fuera de línea, etc., para responder a sus solicitudes, como enviarle la revista electrónica suscrita, obtener sus opiniones, sugerencias o consultas, enviarle regalos de eventos, etc.</li>
        </ul>
      </li>
      <li>Recomendarle contenidos, productos o servicios relevantes. Con su consentimiento, le enviaremos información sobre productos y servicios que puedan interesarle; le invitaremos a participar en actividades de PetJoy (incluidas promociones), encuestas de mercado o encuestas de satisfacción; o le proporcionaremos contenido y servicios personalizados cuando visite sitios web, aplicaciones, etc. Recopilamos la siguiente información:
        <ul>
          <li>Información de contacto: Nombre, correo electrónico, teléfono, nombre de la empresa, cargo, industria, etc., proporcionados por usted para comunicarse con usted, basándonos en su consentimiento, para enviarle información de marketing relevante, invitarle a participar en actividades de PetJoy, sugerirle productos o servicios que puedan interesarle, etc.;</li>
          <li>Registros de interacción: Sus tiempos de carga de páginas web, reproducciones de videos, descargas de archivos PDF, compartir en redes sociales, etc., para comprender sus intereses en nuestros sitios web o productos y proporcionarle información o servicios más precisos y adecuados;</li>
          <li>Información del dispositivo y de la red: Tipo de dispositivo, nombre o modelo del dispositivo, identificadores del dispositivo, tipo y versión del sistema operativo, tipo y versión del navegador, resolución de pantalla, configuración de idioma, dirección IP, proveedor de servicios de Internet, etc., para analizar las visitas a nuestras plataformas en línea y resumir datos estadísticos, con el fin de optimizar continuamente su experiencia de uso.</li>
          <li>Si no desea recibir este tipo de información, puede darse de baja en cualquier momento siguiendo las instrucciones del mensaje de texto o utilizando otros métodos proporcionados por nosotros.</li>
        </ul>
      </li>
      <li>Otras situaciones:
        <ul>
          <li>Solucionar errores si decide enviarnos detalles de errores.</li>
          <li>Proteger la seguridad de nuestros productos, servicios y clientes o usuarios, implementar y mejorar nuestros programas de prevención de pérdidas y fraude.</li>
          <li>Cumplir y hacer cumplir los requisitos legales aplicables, los estándares de la industria relevantes o nuestras políticas.</li>
        </ul>
      </li>
    </ol>

    <h1>Compartir y divulgar información</h1>
    <p>Solo compartimos su información personal en casos razonablemente necesarios. Estos casos incluyen:</p>
    <ol>
      <li>Nuestra empresa matriz o afiliadas, para responder a sus consultas. Todas las empresas del grupo solo pueden usar su información personal de acuerdo con esta política de privacidad.</li>
      <li>Entidades reguladoras, judiciales y de cumplimiento de la ley, así como terceros por razones de seguridad, protección o cumplimiento de la ley. En algunos casos, estamos legalmente obligados a divulgar su información a las autoridades, por ejemplo, para cumplir con obligaciones o procedimientos legales, hacer cumplir nuestros términos, tratar asuntos de seguridad o fraude, o proteger a nuestros usuarios. Para cumplir con términos de procedimientos legales válidos, como citaciones, órdenes judiciales u órdenes de registro, podemos realizar estas divulgaciones con o sin su consentimiento. Generalmente, los términos del procedimiento legal nos prohíben notificarle sobre cualquier divulgación de este tipo. Si una entidad gubernamental no proporciona una citación, orden judicial u orden de registro, podemos solicitar su consentimiento para divulgar información de acuerdo con los requisitos de la entidad gubernamental. También podemos divulgar su información por las siguientes razones:
        <ul>
          <li>Hacer cumplir nuestros términos y condiciones y otros acuerdos, incluida la investigación de posibles violaciones;</li>
          <li>Detectar, prevenir o abordar de otra manera problemas de seguridad, fraude o técnicos;</li>
          <li>Proteger nuestros derechos, propiedad o seguridad, así como los de nuestros usuarios, terceros o el público (intercambiando información con otras empresas y organizaciones con fines de protección contra el fraude y reducción de riesgos crediticios, en la medida en que lo exija o permita la ley).</li>
        </ul>
      </li>
      <li>Terceros en caso de adquisición total o parcial de nuestro negocio. Si ocurre alguna de las siguientes situaciones, también podemos divulgar su información personal a terceros:
        <ul>
          <li>Vendemos, transferimos, fusionamos, consolidamos o reorganizamos cualquier parte de nuestro negocio, o nos fusionamos con otra empresa, adquirimos otra empresa o formamos una empresa conjunta, entonces podemos divulgar sus datos a cualquier nuevo propietario u otro participante en el cambio de nuestro negocio;</li>
          <li>Vendemos o transferimos cualquiera de nuestros activos, entonces la información que poseemos sobre usted puede venderse como parte de esos activos y puede transferirse a cualquier nuevo propietario u otro participante en dicha venta o transferencia.</li>
        </ul>
      </li>
    </ol>

    <h1>Seguridad de la información</h1>
    <p>Independientemente de dónde se almacenen sus datos personales, nos comprometemos a mantener su privacidad e integridad. Nuestras políticas de seguridad de la información y acceso restringen el acceso a nuestros sistemas y tecnologías. Protegemos los datos mediante medidas de protección técnica como el cifrado.</p>
    <p>Desafortunadamente, la transmisión de datos a través de Internet no es completamente segura, aunque hemos tomado y mantenido medidas razonables para proteger su información personal. En caso de un incidente de seguridad, como una fuga de datos, implementaremos un plan de emergencia para evitar la expansión del incidente y le informaremos a través de notificaciones, anuncios, etc.</p>

    <h1>Sus derechos</h1>
    <ol>
      <li>Acceso, corrección, eliminación: Puede acceder, corregir o solicitar la eliminación de su información personal.</li>
      <li>Retiro del consentimiento: Puede retirar su consentimiento otorgado en cualquier momento, pero esto no afectará el procesamiento de su información personal realizado anteriormente con su consentimiento.</li>
      <li>Queja: Tiene derecho a presentar una queja ante una autoridad de protección de datos sobre nuestras prácticas de privacidad.</li>
    </ol>

    <h1>Información de menores</h1>
    <ol>
      <li>Los menores no deben utilizar este sitio web para ningún propósito, a menos que un padre o tutor haya dado su consentimiento. Nos referimos a menores como usuarios menores de 18 años.</li>
      <li>No recopilamos intencionalmente información personal de menores para ningún propósito. Si cree que hemos recopilado información personal de un menor sin el consentimiento de los padres/tutores, o si es padre o tutor de un usuario y desea retirar su consentimiento, contáctenos y eliminaremos dicha información.</li>
    </ol>

    <h1>Sitios web y servicios de terceros</h1>
    <p>Nuestros servicios pueden contener enlaces a sitios web o servicios de terceros (incluidos anuncios y servicios externos). El procesamiento de su información por parte de terceros estará sujeto a la política de privacidad de esos terceros. No somos responsables de las prácticas de privacidad y procesamiento de datos de terceros.</p>

    <h1>Transferencia internacional de datos</h1>
    <p>Para asegurar una experiencia de navegación fluida, puede recibir contenido o enlaces web de terceros fuera de PetJoy y sus socios (en adelante, "terceros"). El equipo de desarrollo no tiene control sobre estos terceros. Puede elegir si desea visitar los enlaces, contenidos, productos y servicios proporcionados por terceros.</p>
    <p>El equipo de desarrollo no puede controlar las políticas de privacidad y protección de datos de terceros. Estos terceros no están sujetos a esta política. Consulte las políticas de protección de privacidad de estos terceros antes de proporcionarles información personal.</p>

    <h1>Cómo contactarnos</h1>
    <p>Si tiene alguna pregunta o inquietud sobre esta política, contáctenos.</p>
    <p>El uso de los servicios del equipo de desarrollo implica que comprende y acepta los términos de esta política de privacidad. Nos comprometemos a seguir protegiendo su información personal y a proporcionar un entorno de servicio seguro y confiable.</p>

    <p style='text-align: right'>Equipo de Desarrollo de PetJoy</p>
    <p style='text-align: right'>8 de julio de 2024</p>
  </el-container>

  <!--法语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'fr'">
    <p>Le groupe de développement de PetJoy (ci-après dénommé "groupe de développement", "nous" et "notre") comprend l'importance de votre vie privée et la respecte. Veuillez lire et comprendre cette Politique de Confidentialité (ci-après "cette politique") avant de nous fournir vos informations personnelles. Cette politique s'applique aux sites web et produits ou services qui affichent cette politique de confidentialité ou qui y sont liés. En particulier, ce site web est exploité par le groupe de développement, qui est responsable du traitement des informations personnelles collectées sur ce site web.</p>

    <h1>Collecte d'informations</h1>
    <p>Comment nous collectons et utilisons vos informations personnelles :</p>
    <ol>
      <li>Informations fournies par vous : Lors de l'enregistrement d'un compte, de la participation à des activités, de l'utilisation des services ou de la communication avec nous, vous devrez peut-être fournir votre nom, vos coordonnées, votre adresse e-mail, etc.</li>
      <li>Informations collectées automatiquement : Pendant l'utilisation de nos services, nous pouvons automatiquement collecter des informations sur votre appareil, des informations de journal, des informations de localisation, etc., afin de fournir et d'optimiser nos services.</li>
      <li>Informations de tiers : Nous pouvons recevoir des données partagées par des partenaires ou des informations obtenues à partir de sources publiques.</li>
    </ol>

    <h1>Utilisation des informations</h1>
    <p>Nous pouvons utiliser les informations collectées pour :</p>
    <ol>
      <li>Créer des comptes. Les clients intéressés par les services de ce site web peuvent créer un compte PetJoy. Ce compte peut vous servir pour l'authentification, la gestion des autorisations et la protection de la sécurité des produits et services lors de l'utilisation des services PetJoy ; entrer en contact avec vous, vous envoyer des notifications importantes, etc. Pour créer le compte, nous collectons les informations personnelles que vous fournissez, y compris votre nom, compte, mot de passe, e-mail, numéro de téléphone, pays ou région.</li>
      <li>Répondre à vos demandes d'interaction. Lorsque vous visitez notre site web, participez à des activités en ligne ou hors ligne, demandez des modifications ou les informations que vous avez demandées (telles que des documents marketing de produits ou services, des livres blancs, des abonnements à des magazines électroniques), et communiquez avec nous pour toute question ou information sur les produits (comme le support technique, les commentaires, suggestions, demandes), nous collectons les informations suivantes :
        <ul>
          <li>Informations de contact : Nom, e-mail, téléphone, adresse, nom de l'entreprise, poste, etc., fournis par vous pour communiquer avec vous, comme vous envoyer le magazine électronique auquel vous vous êtes abonné, répondre à vos demandes, opinions ou suggestions, ou vous envoyer des cadeaux d'événements ;</li>
          <li>Enregistrements d'interaction : Vos demandes d'information, appels, e-mails, enregistrements d'activités en ligne et hors ligne, etc., pour répondre à vos demandes, comme vous envoyer le magazine électronique auquel vous vous êtes abonné, obtenir vos opinions, suggestions ou demandes, vous envoyer des cadeaux d'événements, etc.</li>
        </ul>
      </li>
      <li>Vous recommander des contenus, produits ou services pertinents. Avec votre consentement, nous vous enverrons des informations sur des produits et services susceptibles de vous intéresser ; nous vous inviterons à participer à des activités PetJoy (y compris des promotions), des enquêtes de marché ou des enquêtes de satisfaction ; ou nous vous fournirons des contenus et services personnalisés lorsque vous visitez des sites web, des applications, etc. Nous collectons les informations suivantes :
        <ul>
          <li>Informations de contact : Nom, e-mail, téléphone, nom de l'entreprise, poste, secteur, etc., fournis par vous pour communiquer avec vous, en fonction de votre consentement, pour vous envoyer des informations marketing pertinentes, vous inviter à participer à des activités PetJoy, vous suggérer des produits ou services susceptibles de vous intéresser, etc. ;</li>
          <li>Enregistrements d'interaction : Vos temps de chargement de pages web, lectures de vidéos, téléchargements de fichiers PDF, partages sur les réseaux sociaux, etc., pour comprendre vos intérêts pour nos sites web ou produits et vous fournir des informations ou services plus précis et adaptés ;</li>
          <li>Informations sur l'appareil et le réseau : Type d'appareil, nom ou modèle de l'appareil, identifiants de l'appareil, type et version du système d'exploitation, type et version du navigateur, résolution d'écran, paramètres de langue, adresse IP, fournisseur de services Internet, etc., pour analyser les visites sur nos plateformes en ligne et résumer les données statistiques, afin d'optimiser continuellement votre expérience d'utilisation.</li>
          <li>Si vous ne souhaitez plus recevoir ce type d'informations, vous pouvez vous désabonner à tout moment en suivant les instructions du message texte ou en utilisant d'autres méthodes que nous fournissons.</li>
        </ul>
      </li>
      <li>Autres situations :
        <ul>
          <li>Résoudre des erreurs si vous choisissez de nous envoyer des détails sur les erreurs.</li>
          <li>Protéger la sécurité de nos produits, services et clients ou utilisateurs, mettre en œuvre et améliorer nos programmes de prévention des pertes et de fraude.</li>
          <li>Respecter et appliquer les exigences légales applicables, les normes industrielles pertinentes ou nos politiques.</li>
        </ul>
      </li>
    </ol>

    <h1>Partage et divulgation des informations</h1>
    <p>Nous ne partageons vos informations personnelles que dans des cas raisonnablement nécessaires. Ces cas incluent :</p>
    <ol>
      <li>Notre société mère ou affiliée, pour répondre à vos demandes. Toutes les entreprises du groupe ne peuvent utiliser vos informations personnelles que conformément à cette politique de confidentialité.</li>
      <li>Organismes de réglementation, judiciaires et d'application de la loi, ainsi que des tiers pour des raisons de sécurité, de protection ou de conformité légale. Dans certains cas, nous sommes légalement tenus de divulguer vos informations aux autorités, par exemple, pour respecter des obligations ou procédures légales, faire appliquer nos conditions, traiter des questions de sécurité ou de fraude, ou protéger nos utilisateurs. Pour respecter les termes des procédures légales valides, tels que les citations à comparaître, les ordonnances judiciaires ou les mandats de perquisition, nous pouvons effectuer ces divulgations avec ou sans votre consentement. En général, les termes de la procédure légale nous interdisent de vous informer de toute divulgation de ce type. Si une entité gouvernementale ne fournit pas de citation, d'ordonnance judiciaire ou de mandat de perquisition, nous pouvons demander votre consentement pour divulguer des informations conformément aux exigences de l'entité gouvernementale. Nous pouvons également divulguer vos informations pour les raisons suivantes :
        <ul>
          <li>Faire appliquer nos conditions et autres accords, y compris enquêter sur de possibles violations ;</li>
          <li>Détecter, prévenir ou traiter autrement des problèmes de sécurité, de fraude ou techniques ;</li>
          <li>Protéger nos droits, notre propriété ou notre sécurité, ainsi que ceux de nos utilisateurs, de tiers ou du public (en échangeant des informations avec d'autres entreprises et organisations à des fins de protection contre la fraude et de réduction des risques de crédit, dans la mesure requise ou permise par la loi).</li>
        </ul>
      </li>
      <li>Tiers en cas d'acquisition totale ou partielle de notre entreprise. Si l'une des situations suivantes se produit, nous pouvons également divulguer vos informations personnelles à des tiers :
        <ul>
          <li>Nous vendons, transférons, fusionnons, consolidons ou réorganisons une partie de notre entreprise, ou fusionnons avec une autre entreprise, acquérons une autre entreprise ou formons une coentreprise, alors nous pouvons divulguer vos données à tout nouveau propriétaire ou autre participant au changement de notre entreprise ;</li>
          <li>Nous vendons ou transférons l'un de nos actifs, alors les informations que nous détenons à votre sujet peuvent être vendues comme partie de ces actifs et peuvent être transférées à tout nouveau propriétaire ou autre participant à cette vente ou transfert.</li>
        </ul>
      </li>
    </ol>

    <h1>Sécurité des informations</h1>
    <p>Indépendamment de l'endroit où vos informations personnelles sont stockées, nous nous engageons à maintenir leur confidentialité et leur intégrité. Nos politiques de sécurité de l'information et d'accès restreignent l'accès à nos systèmes et technologies. Nous protégeons les données par des mesures de protection techniques telles que le cryptage.</p>
    <p>Malheureusement, la transmission de données via Internet n'est pas complètement sécurisée, bien que nous ayons pris et maintenu des mesures raisonnables pour protéger vos informations personnelles. En cas d'incident de sécurité, tel qu'une fuite de données, nous mettrons en œuvre un plan d'urgence pour empêcher l'expansion de l'incident et vous informerons via des notifications, des annonces, etc.</p>

    <h1>Vos droits</h1>
    <ol>
      <li>Accès, correction, suppression : Vous pouvez accéder, corriger ou demander la suppression de vos informations personnelles.</li>
      <li>Retrait du consentement : Vous pouvez retirer votre consentement donné à tout moment, mais cela n'affectera pas le traitement de vos informations personnelles effectué précédemment avec votre consentement.</li>
      <li>Plainte : Vous avez le droit de déposer une plainte auprès d'une autorité de protection des données concernant nos pratiques de confidentialité.</li>
    </ol>

    <h1>Informations des enfants</h1>
    <ol>
      <li>Les enfants ne doivent pas utiliser ce site web à quelque fin que ce soit, sauf si un parent ou un tuteur a donné son consentement. Nous entendons par enfants les utilisateurs de moins de 18 ans.</li>
      <li>Nous ne collectons pas intentionnellement d'informations personnelles auprès d'enfants à quelque fin que ce soit. Si vous pensez que nous avons collecté des informations personnelles d'un enfant sans le consentement des parents/tuteurs, ou si vous êtes parent ou tuteur d'un utilisateur et souhaitez retirer votre consentement, veuillez nous contacter et nous supprimerons ces informations.</li>
    </ol>

    <h1>Sites web et services de tiers</h1>
    <p>Nos services peuvent contenir des liens vers des sites web ou des services de tiers (y compris des publicités et des services externes). Le traitement de vos informations par des tiers sera soumis à la politique de confidentialité de ces tiers. Nous ne sommes pas responsables des pratiques de confidentialité et de traitement des données des tiers.</p>

    <h1>Transfert international de données</h1>
    <p>Pour assurer une expérience de navigation fluide, vous pouvez recevoir du contenu ou des liens web de tiers en dehors de PetJoy et de ses partenaires (ci-après dénommés "tiers"). Le groupe de développement n'a aucun contrôle sur ces tiers. Vous pouvez choisir de visiter ou non les liens, contenus, produits et services fournis par ces tiers.</p>
    <p>Le groupe de développement ne peut pas contrôler les politiques de confidentialité et de protection des données des tiers. Ces tiers ne sont pas soumis à cette politique. Veuillez consulter les politiques de protection de la vie privée de ces tiers avant de leur fournir des informations personnelles.</p>

    <h1>Comment nous contacter</h1>
    <p>Si vous avez des questions ou des préoccupations concernant cette politique, veuillez nous contacter.</p>
    <p>L'utilisation des services du groupe de développement implique que vous comprenez et acceptez les termes de cette politique de confidentialité. Nous nous engageons à continuer de protéger vos informations personnelles et à fournir un environnement de service sûr et fiable.</p>

    <p style='text-align: right'>Équipe de Développement PetJoy</p>
    <p style='text-align: right'>8 juillet 2024</p>
  </el-container>

  <!--意大利语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'it'">
    <p>Il team di sviluppo di PetJoy (di seguito "team di sviluppo", "noi" e "nostro") comprende l'importanza della vostra privacy e la rispetta. Si prega di leggere e comprendere questa Politica sulla Privacy (di seguito "questa politica") prima di fornirci le vostre informazioni personali. Questa politica si applica ai siti web e ai prodotti o servizi che mostrano questa politica sulla privacy o che vi sono collegati. In particolare, questo sito web è gestito dal team di sviluppo, che è responsabile del trattamento delle informazioni personali raccolte su questo sito web.</p>

    <h1>Raccolta delle informazioni</h1>
    <p>Come raccogliamo e utilizziamo le vostre informazioni personali:</p>
    <ol>
      <li>Informazioni fornite da voi: Al momento della registrazione di un account, della partecipazione ad attività, dell'utilizzo dei servizi o della comunicazione con noi, potreste dover fornire il vostro nome, i vostri dati di contatto, l'indirizzo e-mail, ecc.</li>
      <li>Informazioni raccolte automaticamente: Durante l'utilizzo dei nostri servizi, potremmo raccogliere automaticamente informazioni sul vostro dispositivo, informazioni sui registri, informazioni sulla posizione, ecc., al fine di fornire e ottimizzare i nostri servizi.</li>
      <li>Informazioni di terzi: Potremmo ricevere dati condivisi dai partner o informazioni ottenute da fonti pubbliche.</li>
    </ol>

    <h1>Uso delle informazioni</h1>
    <p>Possiamo utilizzare le informazioni raccolte per:</p>
    <ol>
      <li>Creare account. I clienti interessati ai servizi di questo sito web possono creare un account PetJoy. Questo account può servirvi per l'autenticazione, la gestione delle autorizzazioni e la protezione della sicurezza dei prodotti e dei servizi durante l'utilizzo dei servizi di PetJoy; per contattarvi, inviarvi notifiche importanti, ecc. Per creare l'account, raccogliamo le informazioni personali che ci fornite, tra cui il vostro nome, account, password, e-mail, numero di telefono, paese o regione.</li>
      <li>Rispondere alle vostre richieste di interazione. Quando visitate il nostro sito web, partecipate ad attività online o offline, richiedete modifiche o informazioni che avete richiesto (come materiali di marketing di prodotti o servizi, libri bianchi, abbonamenti a riviste elettroniche), e comunicate con noi per qualsiasi domanda o informazione sui prodotti (come supporto tecnico, feedback, suggerimenti, richieste), raccogliamo le seguenti informazioni:
        <ul>
          <li>Informazioni di contatto: Nome, e-mail, telefono, indirizzo, nome dell'azienda, posizione, ecc., forniti da voi per comunicare con voi, come inviarvi la rivista elettronica a cui vi siete abbonati, rispondere alle vostre richieste, opinioni o suggerimenti, o inviarvi regali di eventi;</li>
          <li>Registri di interazione: Le vostre richieste di informazioni, chiamate, e-mail, registrazioni di attività online e offline, ecc., per rispondere alle vostre richieste, come inviarvi la rivista elettronica a cui vi siete abbonati, ottenere le vostre opinioni, suggerimenti o richieste, inviarvi regali di eventi, ecc.</li>
        </ul>
      </li>
      <li>Consigliarvi contenuti, prodotti o servizi pertinenti. Con il vostro consenso, vi invieremo informazioni su prodotti e servizi che potrebbero interessarvi; vi inviteremo a partecipare ad attività di PetJoy (comprese promozioni), sondaggi di mercato o sondaggi di soddisfazione; o vi forniremo contenuti e servizi personalizzati quando visitate siti web, app, ecc. Raccogliamo le seguenti informazioni:
        <ul>
          <li>Informazioni di contatto: Nome, e-mail, telefono, nome dell'azienda, posizione, settore, ecc., forniti da voi per comunicare con voi, basandoci sul vostro consenso, per inviarvi informazioni di marketing pertinenti, invitarvi a partecipare ad attività di PetJoy, suggerirvi prodotti o servizi che potrebbero interessarvi, ecc.;</li>
          <li>Registri di interazione: I vostri tempi di caricamento delle pagine web, le riproduzioni di video, i download di file PDF, le condivisioni sui social media, ecc., per comprendere i vostri interessi per i nostri siti web o prodotti e fornirvi informazioni o servizi più precisi e appropriati;</li>
          <li>Informazioni sul dispositivo e sulla rete: Tipo di dispositivo, nome o modello del dispositivo, identificatori del dispositivo, tipo e versione del sistema operativo, tipo e versione del browser, risoluzione dello schermo, impostazioni della lingua, indirizzo IP, fornitore di servizi Internet, ecc., per analizzare le visite alle nostre piattaforme online e riassumere i dati statistici, al fine di ottimizzare continuamente la vostra esperienza di utilizzo.</li>
          <li>Se non desiderate più ricevere questo tipo di informazioni, potete annullare l'iscrizione in qualsiasi momento seguendo le istruzioni del messaggio di testo o utilizzando altri metodi da noi forniti.</li>
        </ul>
      </li>
      <li>Altre situazioni:
        <ul>
          <li>Risolvere errori se scegliete di inviarci dettagli sugli errori.</li>
          <li>Proteggere la sicurezza dei nostri prodotti, servizi e clienti o utenti, implementare e migliorare i nostri programmi di prevenzione delle perdite e delle frodi.</li>
          <li>Rispettare e applicare i requisiti legali applicabili, gli standard di settore pertinenti o le nostre politiche.</li>
        </ul>
      </li>
    </ol>

    <h1>Condivisione e divulgazione delle informazioni</h1>
    <p>Condividiamo le vostre informazioni personali solo in casi ragionevolmente necessari. Questi casi includono:</p>
    <ol>
      <li>La nostra società madre o le affiliate, per rispondere alle vostre richieste. Tutte le aziende del gruppo possono utilizzare le vostre informazioni personali solo in conformità con questa politica di privacy.</li>
      <li>Enti di regolamentazione, giudiziari e di applicazione della legge, nonché terze parti per motivi di sicurezza, protezione o conformità legale. In alcuni casi, siamo legalmente obbligati a divulgare le vostre informazioni alle autorità, ad esempio per rispettare obblighi o procedimenti legali, far rispettare i nostri termini, trattare questioni di sicurezza o frode, o proteggere i nostri utenti. Per rispettare i termini dei procedimenti legali validi, come citazioni, ordinanze giudiziarie o mandati di perquisizione, possiamo effettuare queste divulgazioni con o senza il vostro consenso. In generale, i termini del procedimento legale ci proibiscono di informarvi di qualsiasi divulgazione di questo tipo. Se un ente governativo non fornisce una citazione, un'ordinanza giudiziaria o un mandato di perquisizione, possiamo richiedere il vostro consenso per divulgare informazioni conformemente ai requisiti dell'ente governativo. Possiamo anche divulgare le vostre informazioni per i seguenti motivi:
        <ul>
          <li>Far rispettare i nostri termini e condizioni e altri accordi, comprese le indagini su possibili violazioni;</li>
          <li>Rilevare, prevenire o affrontare altrimenti problemi di sicurezza, frode o tecnici;</li>
          <li>Proteggere i nostri diritti, proprietà o sicurezza, nonché quelli dei nostri utenti, terze parti o del pubblico (scambiando informazioni con altre aziende e organizzazioni a fini di protezione contro le frodi e riduzione del rischio di credito, nella misura richiesta o consentita dalla legge).</li>
        </ul>
      </li>
      <li>Terze parti in caso di acquisizione totale o parziale della nostra azienda. Se si verifica una delle seguenti situazioni, possiamo anche divulgare le vostre informazioni personali a terze parti:
        <ul>
          <li>Vendiamo, trasferiamo, fondiamo, consolidiamo o riorganizziamo una parte della nostra attività, o ci fondiamo con un'altra azienda, acquisiamo un'altra azienda o formiamo una joint venture, possiamo divulgare i vostri dati a qualsiasi nuovo proprietario o altro partecipante al cambiamento della nostra attività;</li>
          <li>Vendiamo o trasferiamo uno dei nostri beni, le informazioni che deteniamo su di voi possono essere vendute come parte di tali beni e possono essere trasferite a qualsiasi nuovo proprietario o altro partecipante a tale vendita o trasferimento.</li>
        </ul>
      </li>
    </ol>

    <h1>Sicurezza delle informazioni</h1>
    <p>Indipendentemente da dove sono memorizzate le vostre informazioni personali, ci impegniamo a mantenerne la riservatezza e l'integrità. Le nostre politiche di sicurezza delle informazioni e di accesso limitano l'accesso ai nostri sistemi e tecnologie. Proteggiamo i dati tramite misure di protezione tecnica come la crittografia.</p>
    <p>Sfortunatamente, la trasmissione di dati tramite Internet non è completamente sicura, anche se abbiamo preso e mantenuto mis ure ragionevoli per proteggere le vostre informazioni personali. In caso di incidente di sicurezza, come una perdita di dati, implementeremo un piano di emergenza per impedire l'espansione dell'incidente e vi informeremo tramite notifiche, annunci, ecc.</p>

    <h1>I vostri diritti</h1>
    <ol>
      <li>Accesso, correzione, eliminazione: Potete accedere, correggere o richiedere l'eliminazione delle vostre informazioni personali.</li>
      <li>Ritiro del consenso: Potete ritirare il vostro consenso dato in qualsiasi momento, ma ciò non influirà sul trattamento delle vostre informazioni personali effettuato precedentemente con il vostro consenso.</li>
      <li>Reclamo: Avete il diritto di presentare un reclamo a un'autorità di protezione dei dati riguardo alle nostre pratiche sulla privacy.</li>
    </ol>

    <h1>Informazioni sui minori</h1>
    <ol>
      <li>I minori non devono utilizzare questo sito web per nessun scopo, a meno che un genitore o tutore non abbia dato il proprio consenso. Per minori si intendono gli utenti di età inferiore ai 18 anni.</li>
      <li>Non raccogliamo intenzionalmente informazioni personali da minori per nessun scopo. Se ritenete che abbiamo raccolto informazioni personali da un minore senza il consenso dei genitori/tutori, o se siete genitore o tutore di un utente e desiderate ritirare il vostro consenso, vi preghiamo di contattarci e cancelleremo tali informazioni.</li>
    </ol>

    <h1>Siti web e servizi di terzi</h1>
    <p>I nostri servizi possono contenere collegamenti a siti web o servizi di terze parti (inclusi annunci pubblicitari e servizi esterni). Il trattamento delle vostre informazioni da parte di terze parti sarà soggetto alla politica sulla privacy di tali terze parti. Non siamo responsabili delle pratiche di privacy e trattamento dei dati di terze parti.</p>

    <h1>Trasferimento internazionale dei dati</h1>
    <p>Per garantire un'esperienza di navigazione fluida, potreste ricevere contenuti o collegamenti web di terze parti al di fuori di PetJoy e dei suoi partner (di seguito "terze parti"). Il team di sviluppo non ha alcun controllo su queste terze parti. Potete scegliere se visitare o meno i collegamenti, contenuti, prodotti e servizi forniti da queste terze parti.</p>
    <p>Il team di sviluppo non può controllare le politiche di privacy e protezione dei dati delle terze parti. Queste terze parti non sono soggette a questa politica. Si prega di consultare le politiche di protezione della privacy di queste terze parti prima di fornire loro informazioni personali.</p>

    <h1>Come contattarci</h1>
    <p>Se avete domande o preoccupazioni riguardanti questa politica, vi preghiamo di contattarci.</p>
    <p>L'utilizzo dei servizi del team di sviluppo implica che comprendete e accettate i termini di questa politica sulla privacy. Ci impegniamo a continuare a proteggere le vostre informazioni personali e a fornire un ambiente di servizio sicuro e affidabile.</p>

    <p style='text-align: right'>Team di Sviluppo PetJoy</p>
    <p style='text-align: right'>8 luglio 2024</p>
  </el-container>

  <!--日语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ja'">
    <p>PetJoy プロジェクト開発チーム（以下「開発チーム」「私たち」と「私たちの」と呼びます）は、お客様のプライバシーの重要性を深く理解しており、お客様のプライバシーを尊重します。個人情報を提供する前に、この「プライバシーポリシー」（以下「本ポリシー」と呼びます）をお読みになり、ご理解ください。本ポリシーは、本プライバシーポリシーを表示する、またはリンクするウェブサイトおよび製品、サービスに適用されます。特に、このウェブサイトは開発チームが運営しており、開発チームは当ウェブサイトで収集される個人情報の個人情報処理者です。</p>

    <h1>情報収集</h1>
    <p>私たちは以下の方法でお客様の個人情報を収集し使用します：</p>
    <ol>
      <li>お客様が提供する情報：アカウントを登録、イベントに参加、サービスを利用、または私たちとコミュニケーションを取る際、名前、連絡先、メールアドレスなどの情報を提供する必要があります。</li>
      <li>自動的に収集される情報：サービスを利用する過程で、お客様のデバイス情報、ログ情報、位置情報などを自動的に収集することがあります。これは、サービスを提供および最適化するためです。</li>
      <li>第三者からの情報：パートナーから共有されたデータや、公開された方法で得られた情報を受け取ることがあります。</li>
    </ol>

    <h1>情報使用</h1>
    <p>収集した情報は以下の目的で使用することがあります：</p>
    <ol>
      <li>アカウント作成。当ウェブサイトサービスに興味を持ったお客様は、ペットジョイ（PetJoy）アカウントを作成できます。このアカウントは、ペットジョイ（PetJoy）製品およびサービスの使用時に身分認証や権限管理を行い、製品およびサービスの安全を守ることができます。また、お客様に連絡を取り、重要な通知を送信するためにも使用されます。アカウントを作成するためには、私たちに提供した個人情報を収集します。これには、入力した名前、アカウント、パスワード、メール、連絡先電話番号、国または地域が含まれます。</li>
      <li>お客様の対話要求に応じる。お客様が当ウェブサイトを訪れ、オンラインまたはオフラインのイベントに参加する、変更を要求する、または要求された情報（例：製品またはサービスのマーケティング資料、ホワイトペーパー、電子ジャーナルの購読など）を提供するため、またはいかなる問題や製品情報について私たちに連絡する際（例：技術サポートを提供する、意見や提案、問い合わせなど）、以下の情報を収集します：
        <ul>
          <li>連絡先情報：お客様が提供する名前、メール、電話、住所、会社名、役職など、連絡を取るため、例えば、お客様が購読する電子ジャーナルを送信し、お客様からの問い合わせ、意見、提案に回答する、またはイベントの贈り物を送るなどに使用します；</li>
          <li>対話記録：情報要求、通話、メール、オンラインおよびオフラインのイベント記録など、お客様の要求に応じるために収集します。</li>
        </ul>
      </li>
      <li>関連するコンテンツ、製品、またはサービスをお勧めする。お客様の同意がある場合、お客様が興味を持つ可能性のある製品やサービスに関する情報を送信します。また、ペットジョイ（PetJoy）の活動（プロモーション活動を含む）、市場調査、または満足度調査にお客様を招待します。または、ウェブサイト、アプリなどのオンラインプラットフォームを訪れる際に、お客様にカスタマイズされたコンテンツやサービスを提供します。以下の情報を収集します：
        <ul>
          <li>連絡先情報：お客様が提供する名前、メール、電話、会社名、役職、所属業界など。連絡を取るため、お客様の同意に基づいて関連するマーケティング情報を送信し、ペットジョイ（PetJoy）の活動に招待し、お客様が興味を持つ可能性のある製品やサービスを推奨するために使用します；</li>
          <li>対話記録：ウェブページのロード、ビデオの再生、PDFファイルのダウンロード、ソーシャルメディアへの共有など、対話行動の記録情報。私たちのウェブサイトや製品への関心点を理解し、より正確で適切な情報やサービスを提供するために使用します；</li>
          <li>デバイスおよびネットワーク情報：デバイスの種類、デバイス名またはモデル、デバイス識別子、オペレーティングシステムのタイプおよびバージョン、ブラウザのタイプおよびバージョン、画面解像度、言語設定、IPアドレス、ネットワークサービスプロバイダーなど、ウェブサイト、アプリなどのオンラインプラットフォームのアクセス効果および統計データをまとめて分析し、お客様の使用体験を継続的に最適化するために使用します。</li>
          <li>このような情報を受け取りたくない場合は、いつでも短信の指示に従うか、私たちが提供する他の方法で退会することができます。</li>
        </ul>
      </li>
      <li>その他の場合：
        <ul>
          <li>エラーの詳細を送信することを選択した場合、エラーを調査します。</li>
          <li>製品、サービス、およびお客様またはユーザーの安全を保護し、損失防止および詐欺防止計画の実行および改善します。</li>
          <li>適用可能な法律要件、関連する業界基準、または私たちのポリシーを遵守し、実行します。</li>
        </ul>
      </li>
    </ol>

    <h1>情報共有および開示</h1>
    <p>私たちは、合理的に必要な場合にのみお客様の個人情報を共有します。このような状況には以下が含まれます：</p>
    <ol>
      <li>私たちのグループ内の会社がお客様の問い合わせに応じてお客様の個人情報を処理します。関連するグループ会社は、本プライバシーポリシーに従ってのみお客様の個人情報を使用できます。</li>
      <li>規制機関、司法機関、および法執行機関、および安全、保護、または法的遵守の目的のための他の第三者。いくつかの場合には、私たちは法的にお客様の情報を当局に開示する必要があります。たとえば、法的義務や手続きに従う、当社の条項を強制する、セキュリティまたは詐欺に関連する問題を処理する、または私たちのユーザーを保護するなどです。効果的な法的手続きの条項に従うため、例えば召喚状、裁判所の命令、または捜索令に従い、お客様の同意が得られているかどうかにかかわらず、これらの開示を行うことがあります。通常、法的手続きの条項は、このような開示についてお客様に通知することを禁じています。政府機関が必要な召喚状、裁判所の命令、または捜索令を提供していない場合、私たちはお客様の同意を求めることがあります。また、以下の目的でお客様の情報を開示することがあります：
        <ul>
          <li>私たちの条項および条件およびその他の契約の強制、これらの文書に違反する可能性のある行為の調査を含む；</li>
          <li>セキュリティ、詐欺、またはその他の技術的問題を検出、防止、または解決する；</li>
          <li>法的に要求または許可された場合、私たち、私たちのユーザー、第三者、または一般公衆の権利、財産、または安全を保護する（詐欺を防ぎ、信用リスクを低減するために他の会社や機関と情報を交換するため）。</li>
        </ul>
      </li>
      <li>全部または一部が私たちまたは私たちのビジネスに関連する第三者によって取得された場合。次のいずれかの状況が発生した場合、私たちはお客様の個人情報を第三者に開示することがあります：
        <ul>
          <li>私たちが事業の一部を売却、譲渡、合併、統合、または再編する、または他の企業と合併、他の企業を買収する、または他の企業と合弁企業を設立する場合、私たちはお客様のデータを新しい所有者またはビジネス変更に関与する他の第三者に開示することがあります；</li>
          <li>私たちが資産を売却または譲渡する場合、お客様に関連する情報はその資産の一部として売却され、新しい所有者またはその売却または譲渡に関与する他の第三者に譲渡される可能性があります。</li>
        </ul>
      </li>
    </ol>

    <h1>情報セキュリティ</h1>
    <p>お客様の個人情報がどこに保存されていても、そのプライバシーと完全性を維持することを約束します。私たちの情報セキュリティおよびアクセスポリシーは、私たちのシステムおよび技術へのアクセスを制限します。データを保護するために暗号化などの技術を使用しています。</p>
    <p>残念ながら、私たちが実施し続けている合理的な措置にもかかわらず、インターネットを介した情報の伝送は完全に安全ではありません。個人情報の漏洩などのセキュリティ事故が発生した場合、私たちは緊急対応計画を起動し、セキュリティ事故の拡大を阻止し、プッシュ通知、公告などの形式でお客様に通知します。</p>

    <h1>お客様の権利</h1>
    <ol>
      <li>アクセス、修正、削除：お客様は、自分の個人情報にアクセスし、修正するか、削除をリクエストすることができます。</li>
      <li>同意の撤回：いつでも、以前に与えた同意を撤回することができますが、これにより同意に基づいて行われた以前の個人情報の処理には影響しません。</li>
      <li>苦情：お客様は、データ保護機関に私たちのプライバシー慣行に対して苦情を提出する権利があります。</li>
    </ol>

    <h1>児童情報</h1>
    <ol>
      <li>児童は、親または保護者が同意を提供していない限り、本ウェブページを何らかの目的で使用してはなりません。私たちが指す児童とは、18歳未満のユーザーです。</li>
      <li>私たちは、意図的に児童の個人情報を収集しません。親/保護者の同意なしに児童の個人情報を保有していると思われる場合、またはお客様がユーザーの親または保護者であり同意を撤回したい場合は、私たちに連絡してください。そのような情報を削除します。</li>
    </ol>

    <h1>第三者のウェブサイトおよびサービス</h1>
    <p>私たちのサービスには、第三者のウェブサイトのリンクやサービス（広告や外部サービスを含む）が含まれることがあります。第三者によるお客様の情報の処理は、その第三者のプライバシーポリシーに従います。私たちは、第三者のプライバシーおよびデータ処理の慣行について責任を負いません。</p>

    <h1>国際データ転送</h1>
    <p>スムーズなブラウジング体験を保証するため、ペットジョイ（PetJoy）およびそのパートナー外部の第三者（以下「第三者」と呼びます）から提供されるコンテンツやネットワークリンクを受け取ることがあります。開発チームは、このような第三者をコントロールしていません。第三者が提供するリンク、コンテンツ、製品、およびサービスにアクセスするかどうかはお客様の選択です。</p>
    <p>開発チームは、第三者のプライバシーおよびデータ保護ポリシーをコントロールすることはできません。これらの第三者は本ポリシーの対象外です。第三者に個人情報を提出する前に、これらの第三者のプライバシー保護ポリシーをご確認ください。</p>

    <h1>お問い合わせ</h1>
    <p>本ポリシーに関するご質問や疑問がある場合は、お問い合わせください。</p>
    <p>開発チームのサービスを使用することにより、お客様は本プライバシーポリシーの条項を理解し、同意するものとします。私たちは、お客様の個人情報を保護し続け、安全で信頼性の高いサービス環境を提供することを約束します。</p>

    <p style='text-align: right'>PetJoy 開発チーム</p>
    <p style='text-align: right'>2024 年 7 月 8 日</p>
  </el-container>

  <!--韩语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ko'">
    <p>애완 동물의 즐거움 | PetJoy 프로젝트 개발 팀 (이하 "개발팀", "우리" 및 "우리의") 은 귀하의 프라이버시의 중요성을 잘 알고 있으며 귀하의 프라이버시를 존중합니다. 개인 정보를 제출하기 전에 이 "개인 정보 보호 정책" (이하 "이 정책") 을 읽고 이해해 주십시오. 이 정책은 이 개인 정보 보호 정책을 표시하거나 이 개인 정보 보호 정책에 링크된 웹사이트 및 제품, 서비스에 적용됩니다. 특히, 이 웹사이트는 개발팀이 운영하며 개발팀은 이 웹사이트에서 수집하는 개인 정보의 개인 정보 처리자입니다.</p>

    <h1>정보 수집</h1>
    <p>우리는 어떻게 귀하의 개인 정보를 수집하고 사용합니까:</p>
    <ol>
      <li>귀하가 제공한 정보: 계정 등록, 활동 참여, 서비스 사용 또는 우리와의 의사소통 시 이름, 연락처, 이메일 주소 등의 정보를 제공해야 할 수 있습니다.</li>
      <li>자동 수집 정보: 서비스를 사용하는 동안에는 장치 정보, 로그 정보, 위치 정보 등을 자동으로 수집하여 서비스 제공 및 최적화에 사용할 수 있습니다.</li>
      <li>제3자 정보: 우리는 파트너가 공유한 데이터를 받거나 공개된 경로로 정보를 얻을 수 있습니다.</li>
    </ol>

    <h1>정보 사용</h1>
    <p>우리는 수집한 정보를 다음과 같은 용도로 사용할 수 있습니다:</p>
    <ol>
      <li>계정 생성. 이 웹사이트 서비스에 관심 있는 고객은 애완 동물의 즐거움 (PetJoy) 계정을 생성할 수 있습니다. 해당 계정은 귀하가 애완 동물의 즐거움 (PetJoy) 제품 및 서비스를 사용할 때 신원을 인증하고, 권한을 관리하여 제품과 서비스의 안전을 보호하며, 귀하와 연락을 취하고 중요한 통지를 보내는 데 사용될 수 있습니다. 계정을 생성하기 위해, 우리는 귀하가 제공하는 개인 정보를 수집합니다. 여기에는 입력한 이름, 계정, 비밀번호, 이메일, 연락처 전화번호, 국가 또는 지역이 포함됩니다.</li>
      <li>귀하의 상호 작용 요청에 응답합니다. 귀하가 우리 웹사이트를 방문하거나 온라인 또는 오프라인 활동에 참여하거나 변경을 요청하거나 요청한 정보 (예: 제품 또는 서비스 마케팅 자료, 백서, 전자 잡지 구독 등) 를 제공하도록 요청하거나 문제 또는 제품 정보에 대해 우리에게 연락할 때 (예: 기술 지원 제공, 의견, 제안, 문의 등), 우리는 다음과 같은 정보를 수집합니다:
        <ul>
          <li>연락처 정보: 이름, 이메일, 전화, 주소, 회사 이름, 직위 등 귀하가 제공한 정보로, 귀하와의 의사소통에 사용됩니다. 예를 들어, 귀하가 구독한 전자 잡지를 보내거나 귀하의 문의, 의견 또는 제안에 답변하거나 행사 선물을 보내는 등;</li>
          <li>상호 작용 기록: 정보 요청, 통화, 이메일, 온라인 및 오프라인 활동 기록 등, 귀하의 요청에 응답하기 위해 귀하가 구독한 전자 잡지를 보내거나 귀하의 의견, 제안 또는 문의를 얻기 위해, 또는 귀하에게 행사 선물을 보내는 등.</li>
        </ul>
      </li>
      <li>귀하에게 관련 내용, 제품 또는 서비스를 추천합니다. 귀하의 동의를 받은 경우, 귀하가 관심을 가질 수 있는 제품 및 서비스에 관한 정보를 보내거나, 귀하를 애완 동물의 즐거움 (PetJoy) 활동 (프로모션 활동 포함), 시장 조사 또는 만족도 조사에 초대하거나, 귀하가 웹사이트, 앱 등 온라인 플랫폼을 방문할 때 개인화된 내용 및 서비스를 제공할 수 있습니다. 우리는 귀하의 다음 정보를 수집합니다:
        <ul>
          <li>연락처 정보: 이름, 이메일, 전화, 회사 이름, 직위, 소속 업계 등 귀하가 제공한 정보로, 귀하와의 의사소통에 사용됩니다. 귀하의 동의를 바탕으로 관련 마케팅 정보를 보내거나, 귀하를 애완 동물의 즐거움 (PetJoy) 활동에 초대하거나, 귀하가 관심을 가질 수 있는 제품이나 서비스를 권장하는 등;</li>
          <li>상호 작용 기록: 웹 페이지 로드, 비디오 재생, PDF 파일 다운로드, 소셜 미디어로 공유 등의 상호 작용 행위 기록 정보. 우리 웹사이트나 제품에 대한 귀하의 관심점을 이해하여 귀하에게 더 정확하고 적절한 정보 또는 서비스를 제공하는 데 사용됩니다;</li>
          <li>장치 및 네트워크 정보: 장치 유형, 장치 이름 또는 모델, 장치 식별자, 운영 체제 유형 및 버전, 브라우저 유형 및 버전, 화면 해상도, 언어 설정, IP 주소, 네트워크 서비스 제공업체 등, 웹사이트, 앱 등 온라인 플랫폼의 방문 효과 및 통계 데이터를 요약 분석하여 귀하의 사용 경험을 지속적으로 최적화하는 데 사용됩니다.</li>
          <li>이러한 정보를 받고 싶지 않다면 언제든지 문자 메시지 프롬프트 또는 다른 방법을 통해 수신 거부를 할 수 있습니다.</li>
        </ul>
      </li>
      <li>기타 상황:
        <ul>
          <li>오류 세부 정보를 보내기로 선택한 경우 오류를 조사합니다.</li>
          <li>우리 제품, 서비스 및 고객 또는 사용자의 안전을 보호하고, 손실 방지 및 사기 방지 프로그램을 실행하고 개선합니다.</li>
          <li>적용 가능한 법적 요구사항, 관련 업계 표준 또는 우리의 정책을 준수하고 실행합니다.</li>
        </ul>
      </li>
    </ol>

    <h1>정보 공유 및 공개</h1>
    <p>우리는 합리적으로 필요한 경우에만 귀하의 개인 정보를 공유합니다. 이러한 상황은 다음과 같습니다:</p>
    <ol>
      <li>우리 그룹 내의 회사가 귀하의 문의에 응답하기 위해 귀하의 개인 정보를 처리합니다. 모든 관련 그룹 회사는 귀하의 개인 정보를 이 개인 정보 보호 정책에 따라만 사용할 수 있습니다.</li>
      <li>규제 기관, 사법 기관 및 집행 기관, 그리고 보안, 보호 또는 법 준수 목적을 위한 기타 제3자. 일부 경우에는 법적 의무를 준수하기 위해 당국에 귀하의 정보를 공개해야 할 수 있습니다. 예를 들어 법적 의무 또는 절차를 준수하거나, 우리의 약관을 집행하거나, 보안 또는 사기 관련 사안을 처리하거나, 우리 사용자를 보호하기 위해 필요합니다. 법적 절차 조항을 준수하기 위해, 예를 들어 소환장, 법원 명령 또는 수색 영장과 같은 경우에는 귀하의 동의를 받거나 받지 않고 이러한 공개를 할 수 있습니다. 일반적으로, 법적 절차의 조항은 우리가 귀하에게 이러한 공개에 대해 통지하는 것을 금지합니다. 정부 기관이 필요한 소환장, 법원 명령 또는 수색 영장을 제공하지 않는 경우, 우리는 정부 기관의 요구에 따라 정보를 공개하기 위해 귀하의 동의를 구할 수 있습니다. 우리는 또한 다음과 같은 목적으로 귀하의 정보를 공개할 수 있습니다:
        <ul>
          <li>우리의 약관 및 기타 계약을 집행하고, 이러한 문서의 위반 행위를 조사하는 것;</li>
          <li>보안, 사기 또는 기타 기술 문제를 발견, 방지 또는 해결하는 것;</li>
          <li>법적으로 요구되거나 허용되는 경우 우리, 우리 사용자, 제3자 또는 일반 대중의 권리, 재산 또는 안전을 보호하는 것 (사기 방지 및 신용 위험 감소를 위해 다른 회사 및 기관과 정보를 교환).</li>
        </ul>
      </li>
      <li>전부 또는 일부가 우리 또는 우리 사업을 인수하는 제3자. 다음과 같은 경우에도 우리는 귀하의 개인 정보를 제3자에게 공개할 수 있습니다:
        <ul>
          <li>우리가 어떤 부분의 사업을 판매, 양도, 합병, 통합 또는 개편하거나 다른 기업과 합병, 다른 기업을 인수하거나 그들과 합작 투자를 구성하는 경우, 우리는 귀하의 데이터를 새로운 소유자나 우리 사업 변동에 참여하는 다른 제3자에게 공개할 수 있습니다;</li>
          <li>우리가 우리의 어떤 자산을 판매하거나 양도하는 경우, 귀하와 관련된 정보는 그러한 자산의 일부로 판매될 수 있으며 새로운 소유자나 그러한 판매 또는 양도에 참여하는 다른 제3자에게 전달될 수 있습니다.</li>
        </ul>
      </li>
    </ol>

    <h1>정보 보안</h1>
    <p>귀하의 개인 정보가 어디에 저장되든, 우리는 그것의 개인 정보 보호 및 완전성을 유지하기 위해 약속합니다. 우리의 정보 보안 및 접근 정책은 우리 시스템 및 기술에 대한 접근을 제한하며, 데이터 보호를 위해 암호화와 같은 기술을 사용하여 보호 조치를 취합니다.</p>
    <p>유감스럽게도, 우리가 취한 합리적인 보호 조치에도 불구하고 인터넷을 통한 정보 전송은 완전히 안전하지 않습니다. 개인 정보 유출과 같은 보안 사고가 발생한 경우, 우리는 비상 계획을 시작하여 보안 사고의 확산을 막고, 푸시 알림, 공고 등의 형태로 귀하에게 알릴 것입니다.</p>

    <h1>귀하의 권리</h1>
    <ol>
      <li>접근, 정정, 삭제: 귀하는 귀하의 개인 정보에 접근하고, 정정하거나, 삭제를 요청할 수 있습니다.</li>
      <li>동의 철회: 언제든지 이전에 제공한 동의를 철회할 수 있으며, 이는 귀하의 동의에 기반하여 이전에 이루어진 개인 정보 처리에 영향을 미치지 않습니다.</li>
      <li>불만 제기: 귀하는 데이터 보호 기관에 우리의 개인 정보 보호 관행에 대해 불만을 제기할 권리가 있습니다.</li>
    </ol>

    <h1>어린이 정보</h1>
    <ol>
      <li>어린이는 부모 또는 보호자가 동의를 제공한 경우에만 어떠한 목적으로든 이 웹 페이지를 사용할 수 있습니다. 우리가 말하는 어린이는 18세 미만의 사용자입니다.</li>
      <li>우리는 어떠한 목적으로도 의도적으로 어린이의 개인 정보를 수집하지 않습니다. 부모/보호자의 동의 없이 어린이의 개인 정보를 보유하고 있다고 생각되거나 귀하가 사용자의 부모 또는 보호자이며 동의를 철회하고 싶다면, 저희에게 연락해 주시면 해당 정보를 삭제하겠습니다.</li>
    </ol>

    <h1>제3자 웹사이트 및 서비스</h1>
    <p>우리의 서비스는 제3자 웹사이트 링크 또는 서비스 (광고 및 외부 서비스 포함) 를 포함할 수 있습니다. 제3자에 의해 처리되는 귀하의 정보는 해당 제3자의 개인 정보 보호 정책에 적용되며, 우리는 제3자의 프라이버시 및 데이터 처리 관행에 대해 책임을 지지 않습니다.</p>

    <h1>국제 데이터 전송</h1>
    <p>원활한 브라우징 경험을 위해, 귀하는 애완 동물의 즐거움 (PetJoy) 및 그 파트너 외부의 제3자 (이하 "제3자") 가 제공하는 내용이나 네트워크 링크를 받을 수 있습니다. 개발팀은 이러한 제3자를 통제할 수 없습니다. 제3자가 제공하는 링크, 내용, 제품 및 서비스를 사용할지 여부는 귀하가 선택할 수 있습니다.</p>
    <p>개발팀은 제3자의 개인 정보 보호 및 데이터 보호 정책을 통제할 수 없으며, 이러한 제3자는 이 정책의 적용을 받지 않습니다. 제3자에게 개인 정보를 제출하기 전에, 이러한 제3자의 개인 정보 보호 정책을 참조하십시오.</p>

    <h1>문의하기</h1>
    <p>이 정책에 대한 질문이나 의문이 있으시면 저희에게 연락해 주십시오.</p>
    <p>개발팀의 서비스를 사용함으로써 귀하는 이 개인 정보 보호 정책의 조항을 이해하고 동의하며, 우리는 귀하의 개인 정보를 지속적으로 보호하고 안전하고 신뢰할 수 있는 서비스 환경을 제공하기 위해 노력할 것임을 약속합니다.</p>

    <p style='text-align: right'>PetJoy 개발 팀</p>
    <p style='text-align: right'>2024 년 7 월 8 일</p>
  </el-container>

  <!--葡萄牙语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'pt'">
    <p>PetJoy | A equipe de desenvolvimento do Projeto PetJoy (doravante referida como "Equipe de Desenvolvimento", "nós" e "nosso") reconhece a importância da sua privacidade e respeita sua privacidade. Antes de nos enviar suas informações pessoais, por favor leia e entenda esta "Política de Privacidade" (doravante referida como "esta Política"). Esta Política se aplica a sites e produtos ou serviços que exibem esta política de privacidade ou estão ligados a esta política de privacidade. Especificamente, este site é operado pela equipe de desenvolvimento, que é o processador de informações pessoais coletadas neste site.</p>

    <h1>Coleta de Informações</h1>
    <p>Como coletamos e usamos suas informações pessoais:</p>
    <ol>
      <li>Informações fornecidas por você: ao registrar uma conta, participar de atividades, usar serviços ou se comunicar conosco, você pode precisar fornecer informações como nome, contato, endereço de e-mail, etc.</li>
      <li>Informações coletadas automaticamente: enquanto você usa nossos serviços, podemos coletar automaticamente informações sobre seu dispositivo, registros de logs, localização, etc., para fornecer e otimizar nossos serviços.</li>
      <li>Informações de terceiros: podemos receber dados compartilhados por parceiros ou obter informações por meios públicos.</li>
    </ol>

    <h1>Uso de Informações</h1>
    <p>Poderíamos usar as informações coletadas para:</p>
    <ol>
      <li>Criar uma conta. Clientes interessados nos serviços do site podem criar uma conta PetJoy. Esta conta pode fornecer autenticação de identidade e gerenciamento de permissões para proteger a segurança de produtos e serviços; entrar em contato com você e enviar notificações importantes. Para criar uma conta, coletamos suas informações pessoais fornecidas, incluindo nome, conta, senha, e-mail, telefone de contato, país ou região.</li>
      <li>Responder às suas solicitações de interação. Quando você visita nosso site, participa de atividades on-line ou off-line, solicita mudanças, ou solicita informações que você pediu (como materiais de marketing de produtos ou serviços, white papers, assinaturas de revistas eletrônicas) e entra em contato conosco sobre quaisquer problemas ou informações sobre produtos (como fornecimento de suporte técnico, fornecimento de feedback, sugestões, perguntas, etc.), coletamos as seguintes informações:
        <ul>
          <li>Informações de contato: nome, e-mail, telefone, endereço, nome da empresa, cargo etc., fornecidos por você, usados para se comunicar com você, como enviar a revista eletrônica que você assinou, responder a suas perguntas, comentários ou sugestões, ou enviar presentes de eventos;</li>
          <li>Registros de interação: seus pedidos de informações, chamadas, e-mails, registros de atividades on-line e off-line, etc., respondendo a seus pedidos, como enviar a revista eletrônica que você assinou, obter seus comentários, sugestões ou perguntas, enviar presentes de eventos, etc.</li>
        </ul>
      </li>
      <li>Recomendar conteúdo, produtos ou serviços relevantes. Com o seu consentimento, enviar informações sobre produtos e serviços que possam ser de seu interesse; convidá-lo para participar de atividades da PetJoy (incluindo atividades promocionais), pesquisas de mercado ou pesquisas de satisfação; ou fornecer conteúdo e serviços personalizados quando você visita sites, APPs e outras plataformas online. Coletamos as seguintes informações:
        <ul>
          <li>Informações de contato: nome, e-mail, telefone, nome da empresa, cargo, setor de atuação etc., fornecidos por você, usados para se comunicar com você, com base no seu consentimento, para enviar informações de marketing relacionadas, convidá-lo para atividades da PetJoy, promover produtos ou serviços que possam ser do seu interesse, etc.;</li>
          <li>Registros de interação: informações do registro de suas ações, como carregar páginas da web, reproduzir vídeos, baixar arquivos PDF, compartilhar em mídias sociais, etc. Compreendendo seus pontos de interesse em nosso site ou produtos para fornecer informações ou serviços mais precisos e adequados;</li>
          <li>Informações do dispositivo e da rede: tipo de dispositivo, nome ou modelo do dispositivo, identificador do dispositivo, tipo e versão do sistema operacional, tipo e versão do navegador, resolução da tela, configurações de idioma, endereço IP, provedor de serviços de rede etc., usados para analisar de forma agregada a eficácia das visitas ao site, APPs e outras plataformas online, e estatísticas para otimizar continuamente sua experiência de uso.</li>
          <li>Se você não deseja receber essas informações, você pode cancelar a inscrição a qualquer momento, conforme as instruções de SMS ou outros métodos que fornecemos.</li>
        </ul>
      </li>
      <li>Outras situações:
        <ul>
          <li>Na situação em que você escolhe nos enviar detalhes de um erro para investigação.</li>
          <li>Proteger a segurança de nossos produtos, serviços e clientes ou usuários, implementar e melhorar nossos planos de prevenção de perdas e anti-fraude.</li>
          <li>Cumprir e executar os requisitos legais aplicáveis, padrões da indústria relacionados ou nossas políticas.</li>
        </ul>
      </li>
    </ol>

    <h1>Compartilhamento e Divulgação de Informações</h1>
    <p>Só compartilhamos suas informações pessoais quando estritamente necessário. Essas situações incluem:</p>
    <ol>
      <li>Empresas dentro de nosso grupo para processar suas informações pessoais em resposta às suas consultas. Todas as empresas relacionadas do grupo só podem usar suas informações pessoais de acordo com esta Política de Privacidade.</li>
      <li>Reguladores, autoridades judiciais e agências de aplicação da lei, e outros terceiros para fins de segurança, proteção ou conformidade legal. Em alguns casos, podemos ser legalmente obrigados a divulgar suas informações às autoridades, como para cumprir obrigações legais ou processos, aplicar nossos termos, lidar com questões relacionadas à segurança ou fraude, ou proteger nossos usuários. Para cumprir os termos de um processo legal válido, como uma intimação, ordem judicial ou mandado de busca, podemos fazer essas divulgações com ou sem seu consentimento. Geralmente, os termos do processo legal proíbem-nos de notificá-lo sobre tais divulgações. Se uma entidade governamental não fornecer a intimação, ordem judicial ou mandado de busca necessário, podemos buscar seu consentimento para divulgar as informações conforme solicitado pela entidade governamental. Também podemos divulgar suas informações para:
        <ul>
          <li>Aplicar nossos termos e condições e outros acordos, incluindo a investigação de qualquer atividade que possa violar esses documentos;</li>
          <li>Identificar, prevenir ou resolver questões de segurança, fraude ou técnicas;</li>
          <li>Proteger os direitos, propriedade ou segurança de nós, nossos usuários, terceiros ou o público em geral (por exemplo, trocando informações com outras empresas e organizações para fins de proteção contra fraude e redução de risco de crédito).</li>
        </ul>
      </li>
      <li>Terceiros que adquirem todo ou parte de nossos negócios. Se ocorrer qualquer das seguintes situações, também podemos divulgar suas informações pessoais a terceiros:
        <ul>
          <li>Se vendermos, transferirmos, fundirmos, incorporarmos ou reestruturarmos qualquer parte de nosso negócio, ou nos fundirmos com, adquirirmos ou formarmos uma joint venture com outra empresa, podemos divulgar seus dados a qualquer novo proprietário ou outras partes envolvidas em nossas mudanças de negócios;</li>
          <li>Se vendermos ou transferirmos qualquer um de nossos ativos, suas informações relacionadas podem ser vendidas como parte desses ativos e podem ser transferidas para qualquer novo proprietário ou outras partes envolvidas na venda ou transferência.</li>
        </ul>
      </li>
    </ol>

    <h1>Segurança da Informação</h1>
    <p>Independente de onde suas informações pessoais estejam armazenadas, comprometemo-nos a manter sua privacidade e integridade. Nossa política de segurança e acesso à informação limita o acesso aos nossos sistemas e tecnologias, e usamos medidas de proteção, como criptografia, para proteger os dados.</p>
    <p>Infelizmente, apesar de termos implementado e mantido medidas razoáveis para proteger suas informações pessoais, a transmissão de informações pela internet não é completamente segura. Caso ocorra um incidente de segurança, como um vazamento de informações pessoais, iniciaremos um plano de emergência para impedir a expansão do incidente e informaremos você por meio de notificações push, anúncios e outros métodos.</p>

    <h1>Seus Direitos</h1>
    <ol>
      <li>Acesso, correção, exclusão: Você pode acessar, corrigir ou solicitar a exclusão de suas informações pessoais.</li>
      <li>Retirada do consentimento: A qualquer momento, você pode retirar o consentimento previamente concedido, mas isso não afetará o processamento de informações pessoais baseado em seu consentimento anterior.</li>
      <li>Reclamação: Você tem o direito de reclamar à autoridade de proteção de dados sobre nossas práticas de privacidade.</li>
    </ol>

    <h1>Informações de Crianças</h1>
    <ol>
      <li>Crianças não podem usar este site para qualquer finalidade, a menos que os pais ou responsáveis tenham fornecido consentimento. Referimo-nos a crianças como usuários com menos de 18 anos de idade.</li>
      <li>Não coletamos intencionalmente informações pessoais de crianças para qualquer propósito. Se você acredita que possuímos informações pessoais de uma criança sem o consentimento dos pais/responsáveis, ou você é o pai ou responsável de um usuário e deseja retirar o consentimento, entre em contato conosco e removeremos essas informações.</li>
    </ol>

    <h1>Sites e Serviços de Terceiros</h1>
    <p>Nosso serviço pode incluir links para sites de terceiros ou serviços (incluindo publicidade e serviços externos). As informações processadas por terceiros serão sujeitas à política de privacidade desses terceiros, e não somos responsáveis pelas práticas de privacidade e processamento de dados desses terceiros.</p>

    <h1>Transferência Internacional de Dados</h1>
    <p>Para garantir uma experiência de navegação fluida, você pode receber conteúdo ou links de rede fornecidos por terceiros externos à PetJoy e seus parceiros (doravante referidos como "terceiros"). A equipe de desenvolvimento não tem controle sobre esses terceiros. Você pode escolher se acessa ou não links, conteúdo, produtos e serviços fornecidos por terceiros.</p>
    <p>A equipe de desenvolvimento não controla as políticas de privacidade e proteção de dados desses terceiros, e esses terceiros não estão sujeitos a esta política. Antes de enviar informações pessoais a terceiros, consulte as políticas de proteção de privacidade desses terceiros.</p>

    <h1>Como nos Contatar</h1>
    <p>Se você tiver qualquer dúvida ou preocupação sobre esta política, por favor, entre em contato conosco.</p>
    <p>Ao usar os serviços da equipe de desenvolvimento, você entende e concorda com os termos desta Política de Privacidade. Comprometemo-nos a continuar protegendo suas informações pessoais e fornecer um ambiente de serviço seguro e confiável.</p>

    <p style='text-align: right'>Equipe de Desenvolvimento PetJoy</p>
    <p style='text-align: right'>8 de julho de 2024</p>
  </el-container>

  <!--俄语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ru'">
    <p>Команда разработки проекта PetJoy (далее "Команда разработки", "мы" и "наш") осознает важность вашей конфиденциальности и уважает её. Пожалуйста, прочитайте и поймите эту "Политику конфиденциальности" (далее "Политика") перед тем, как предоставлять нам свои личные данные. Эта Политика применяется к сайтам и продуктам или услугам, которые отображают эту политику конфиденциальности или содержат ссылку на неё. В частности, этот веб-сайт управляется Командой разработки, которая является обработчиком личных данных, собранных на этом сайте.</p>

    <h1>Сбор информации</h1>
    <p>Как мы собираем и используем ваши личные данные:</p>
    <ol>
      <li>Информация, предоставляемая вами: при регистрации аккаунта, участии в активностях, использовании услуг или в общении с нами, вы можете предоставить такие данные, как имя, контактная информация, адрес электронной почты и т.д.</li>
      <li>Автоматически собираемая информация: в процессе использования наших услуг мы можем автоматически собирать информацию о вашем устройстве, журналах, местоположении и т.д., чтобы предоставлять и улучшать наши услуги.</li>
      <li>Информация от третьих сторон: мы можем получать данные, которые делится с нами нашими партнёрами, или получать информацию из открытых источников.</li>
    </ol>

    <h1>Использование информации</h1>
    <p>Мы можем использовать собранную информацию для следующих целей:</p>
    <ol>
      <li>Создание аккаунта. Клиенты, заинтересованные в услугах сайта, могут создать аккаунт PetJoy. Этот аккаунт может использоваться для аутентификации личности и управления доступом, чтобы обеспечить безопасность продуктов и услуг; для связи с вами и отправки важных уведомлений. Для создания аккаунта мы собираем предоставленные вами личные данные, включая имя, логин, пароль, электронную почту, контактный телефон, страну или регион.</li>
      <li>Ответ на ваши запросы взаимодействия. Когда вы посещаете наш сайт, участвуете в онлайн или офлайн мероприятиях, запрашиваете изменения или предоставляете запрошенную информацию (например, маркетинговые материалы по продуктам или услугам, белые книги, подписку на электронные журналы) и связываетесь с нами по любым вопросам или информации о продуктах (например, предоставление технической поддержки, предложения, отзывы, запросы и т.д.), мы собираем следующую информацию:
        <ul>
          <li>Контактная информация: предоставленные вами имя, электронная почта, телефон, адрес, название компании, должность и т.д., используемые для связи с вами, например, для отправки подписанного вами электронного журнала, ответов на ваши запросы, комментарии или предложения, или для отправки подарков с мероприятий;</li>
          <li>Записи взаимодействий: ваши запросы информации, звонки, электронные письма, записи онлайн и офлайн мероприятий и т.д., отвечая на ваши запросы, например, отправляя подписанные вами электронные журналы, получая ваше мнение, предложения или запросы, отправляя подарки с мероприятий и т.д.</li>
        </ul>
      </li>
      <li>Рекомендация соответствующего контента, продуктов или услуг. С вашего согласия, отправлять информацию о продуктах и услугах, которые могут быть вам интересны; приглашать вас участвовать в мероприятиях PetJoy (включая рекламные акции), проводить исследования рынка или опросы удовлетворенности; или предоставлять персонализированный контент и услуги, когда вы посещаете сайты, приложения и другие онлайн платформы. Мы собираем следующую информацию:
        <ul>
          <li>Контактная информация: предоставленные вами имя, электронная почта, телефон, название компании, должность, отрасль и т.д., используемые для связи с вами, на основе вашего согласия, для отправки связанных маркетинговых сообщений, приглашения на мероприятия PetJoy, продвижения продуктов или услуг, которые могут быть вам интересны, и т.д.;</li>
          <li>Записи взаимодействий: информация о ваших действиях, таких как загрузка веб-страниц, воспроизведение видео, загрузка PDF-файлов, деление в социальных сетях и т.д. Понимание ваших интересов к нашему сайту или продуктам для предоставления более точной и соответствующей информации или услуг;</li>
          <li>Информация об устройстве и сети: тип устройства, название или модель устройства, идентификатор устройства, тип и версия операционной системы, тип и версия браузера, разрешение экрана, языковые настройки, IP-адрес, провайдер сетевых услуг и т.д., используемые для агрегированного анализа эффективности посещений веб-сайта, приложений и других онлайн платформ, и статистики для непрерывной оптимизации вашего опыта использования.</li>
          <li>Если вы не желаете получать такую информацию, вы можете в любое время отказаться от подписки, следуя инструкциям в SMS или другим методам, которые мы предоставляем.</li>
        </ul>
      </li>
      <li>Другие ситуации:
        <ul>
          <li>В случае, если вы выберете отправить нам детали ошибки для исследования.</li>
          <li>Защита безопасности наших продуктов, услуг и клиентов или пользователей, реализация и улучшение наших планов предотвращения потерь и борьбы с мошенничеством.</li>
          <li>Соблюдение и выполнение применимых законодательных требований, связанных отраслевых стандартов или наших политик.</li>
        </ul>
      </li>
    </ol>

    <h1>Распространение и разглашение информации</h1>
    <p>Мы делимся вашей личной информацией только тогда, когда это строго необходимо. Такие ситуации включают в себя:</p>
    <ol>
      <li>Компании внутри нашей группы для обработки вашей личной информации в ответ на ваши запросы. Все связанные компании группы могут использовать вашу личную информацию только в соответствии с этой Политикой конфиденциальности.</li>
      <li>Регулирующие органы, судебные органы и правоохранительные агентства, а также другие третьи стороны по причинам безопасности, защиты или соблюдения законодательства. В некоторых случаях мы можем быть юридически обязаны раскрыть вашу информацию властям, например, для соблюдения юридических обязательств или процессов, применения наших условий, решения вопросов, связанных с безопасностью или мошенничеством, или защиты наших пользователей. Для соблюдения условий действительного юридического процесса, таких как повестка, судебное постановление или ордер на обыск, мы можем совершать такие раскрытия с вашего согласия или без него. Обычно условия юридического процесса запрещают нам уведомлять вас о таких раскрытиях. Если государственный орган не предоставит необходимую повестку, судебное постановление или ордер на обыск, мы можем запросить ваше согласие для раскрытия информации в соответствии с запросом государственного органа. Также мы можем раскрывать вашу информацию для:
        <ul>
          <li>Применения наших условий и условий других соглашений, включая расследование любой деятельности, которая может нарушать эти документы;</li>
          <li>Выявления, предотвращения или решения проблем безопасности, мошенничества или технических;</li>
          <li>Защиты прав, собственности или безопасности нас, наших пользователей, третьих сторон или общественности (например, обмен информацией с другими компаниями и организациями для защиты от мошенничества и снижения кредитного риска).</li>
        </ul>
      </li>
      <li>Третьи стороны, приобретающие всю или часть нашего бизнеса. Если происходит любая из следующих ситуаций, мы также можем раскрыть вашу личную информацию третьим сторонам:
        <ul>
          <li>Если мы продаем, передаем, сливаем, интегрируем или реорганизуем любую часть нашего бизнеса, или сливаемся с, приобретаем или формируем совместное предприятие с другой компанией, мы можем раскрыть ваши данные любому новому владельцу или другим сторонам, участвующим в наших изменениях бизнеса;</li>
          <li>Если мы продаем или передаем любые наши активы, ваши связанные с этим информация может быть продана как часть этих активов и может быть передана любому новому владельцу или другим сторонам, участвующим в этой продаже или передаче.</li>
        </ul>
      </li>
    </ol>

    <h1>Безопасность информации</h1>
    <p>Независимо от того, где хранятся ваши личные данные, мы обязуемся поддерживать их конфиденциальность и целостность. Наша политика безопасности и доступа к информации ограничивает доступ к нашим системам и технологиям, и мы используем такие меры защиты, как шифрование, для защиты данных.</p>
    <p>К сожалению, несмотря на то, что мы внедрили и поддерживаем разумные меры для защиты ваших личных данных, передача информации через Интернет не является полностью безопасной. В случае инцидента безопасности, такого как утечка личных данных, мы запустим план чрезвычайных мероприятий, чтобы предотвратить распространение инцидента, и уведомим вас с помощью push-уведомлений, объявлений и других методов.</p>

    <h1>Ваши права</h1>
    <ol>
      <li>Доступ, исправление, удаление: Вы можете получить доступ, исправить или запросить удаление ваших личных данных.</li>
      <li>Отзыв согласия: В любое время вы можете отозвать ранее предоставленное согласие, но это не повлияет на обработку личных данных, основанную на вашем предыдущем согласии.</li>
      <li>Жалоба: Вы имеете право подать жалобу в орган по защите данных на наши практики конфиденциальности.</li>
    </ol>

    <h1>Информация о детях</h1>
    <ol>
      <li>Дети не могут использовать этот сайт для каких-либо целей, если только родители или опекуны не предоставили согласие. Под детьми мы понимаем пользователей младше 18 лет.</li>
      <li>Мы не собираем намеренно личные данные детей для каких-либо целей. Если вы считаете, что у нас есть личные данные ребенка без согласия родителей/опекунов, или вы являетесь родителем или опекуном пользователя и хотите отозвать согласие, пожалуйста, свяжитесь с нами, и мы удалим такие данные.</li>
    </ol>

    <h1>Сайты и услуги третьих сторон</h1>
    <p>Наш сервис может включать ссылки на веб-сайты третьих сторон или услуги (включая рекламу и внешние услуги). Информация, обрабатываемая третьими сторонами, будет подчиняться политике конфиденциальности этих третьих сторон, и мы не несем ответственности за практики конфиденциальности и обработки данных этих третьих сторон.</p>

    <h1>Международная передача данных</h1>
    <p>Для обеспечения плавного взаимодействия с сайтом вы можете получать контент или ссылки на сеть, предоставленные третьими сторонами, не связанными с PetJoy и ее партнерами (далее "третьи стороны"). Команда разработки не контролирует этих третьих сторон. Вы можете выбрать, использовать ли ссылки, контент, продукты и услуги, предоставляемые третьими сторонами.</p>
    <p>Команда разработки не контролирует политики конфиденциальности и защиты данных этих третьих сторон, и эти третьи стороны не подпадают под действие этой Политики. Перед тем, как предоставить личные данные третьим сторонам, ознакомьтесь с их политиками защиты конфиденциальности.</p>

    <h1>Как с нами связаться</h1>
    <p>Если у вас есть вопросы или сомнения относительно этой Политики, пожалуйста, свяжитесь с нами.</p>
    <p>Используя услуги Команды разработки, вы понимаете и соглашаетесь с условиями этой Политики конфиденциальности. Мы обязуемся продолжать защищать вашу личную информацию и предоставлять безопасную и надежную среду обслуживания.</p>

    <p style='text-align: right'>Команда разработчиков PetJoy</p>
    <p style='text-align: right'>8 июля 2024 года</p>
  </el-container>

  <!--汉语（默认语言）版本-->
  <el-container direction='vertical' v-else>
    <p>宠悦 | PetJoy 项目开发组（下文简称“开发组”、“我们”和“我们的”）深知隐私对您的重要性，并会尊重您的隐私。请在向我们提交个人信息之前，阅读、了解本《隐私政策》（下文简称“本政策”）。本政策适用于显示本隐私政策、或链接至本隐私政策的网站和产品、服务。特别的，本网站由开发组运营，开发组是该网站所收集的个人信息的个人信息处理者。</p>

    <h1>信息收集</h1>
    <p>我们如何收集和使用您的个人信息：</p>
    <ol>
      <li>您提供的信息：在注册账号、参与活动、使用服务或与我们交流时，您可能需要提供姓名、联系方式、电邮地址等信息。</li>
      <li>自动收集的信息：在您使用服务过程中，我们可能自动收集您的设备信息、日志信息、位置信息等，用以提供和优化我们的服务。</li>
      <li>第三方信息：我们可能接收合作伙伴分享的数据，或公开途径获得的信息。</li>
    </ol>

    <h1>信息使用</h1>
    <p>我们可能将收集的信息用于：</p>
    <ol>
      <li>创建账号。对本网站服务感兴趣的客户可以创建宠悦（PetJoy）账号。该账号可为您使用宠悦（PetJoy）产品服务时提供身份认证，权限管理以保护产品和服务的安全；与您联系，向您发送重要通知等。为创建账号，我们会收集您向我们提供的个人信息，包括您输入的姓名、账号、密码、邮箱、联系电话、国家或地区。</li>
      <li>响应您的互动要求。当您访问我们的网站，参加线上或线下活动，要求进行变更或者要求提供您请求的信息（例如产品或服务的营销资料、白皮书、订阅电子杂志），以及就任何问题或产品信息与我们联系时（例如提供技术支持，向我们提供意见、建议、询问等），我们会收集您的如下信息：
        <ul>
          <li>联系信息：您提供的姓名、邮箱、电话、地址、公司名称、职位等，用于与您沟通，如向您发送您订阅的电子杂志，回复您对我们的问询、意见或建议，或向您寄送活动礼品等；</li>
          <li>互动记录：您的信息请求、通话、电子邮件、线上线下活动记录等，响应您的请求，如向您发送您订阅的电子杂志，获得您对我们的意见、建议或询问，向您寄送活动礼品等。</li>
        </ul>
      </li>
      <li>为您推荐相关内容、产品或服务。在您同意的情况下，向您发送有关您可能感兴趣的产品和服务的信息；邀请您参与宠悦（PetJoy）活动（包括促销活动）、市场调查或满意度调查；或在您访问网站、APP等线上平台时为您提供个性化的内容及服务。我们会收集您的如下信息：
        <ul>
          <li>联系信息：您提供的姓名、邮箱、电话、公司名称、职位、所属行业等。用于与您沟通，基于您的同意，向您发送相关营销信息，邀请您参加宠悦（PetJoy）活动，向您推送您可能感兴趣的产品或服务等；</li>
          <li>互动记录：您加载网页、播放视频、下载PDF文件、分享至社交媒体等互动行为记录信息。了解您对我们网站或产品的关注点，以便为您提供更准确、恰当的信息或服务；</li>
          <li>设备及网络信息：设备类型、设备名称或型号、设备识别符、操作系统类型及版本、浏览器类型和版本、屏幕分辨率、语言设置、IP地址、网络服务提供商等，用于汇总分析网站、APP等线上平台的访问效果及统计数据，以便持续优化您的使用体验。</li>
          <li>如果您不想接收此类信息，则可以随时根据短信提示或我们提供的其他方式进行退订。</li>
        </ul>
      </li>
      <li>其他情况：
        <ul>
          <li>在您选择向我们发送错误详情的情况下排查错误。</li>
          <li>保护我们产品、服务和客户或用户的安全，执行与改善我们的防损和反欺诈计划。</li>
          <li>遵从和执行适用的法律要求，相关的行业标准或我们的政策。</li>
        </ul>
      </li>
    </ol>

    <h1>信息分享和披露</h1>
    <p>我们仅在合理必要的情况下共享您的个人信息。这类情况包括：</p>
    <ol>
      <li>我们集团内的公司为回应您的问询而处理您的个人信息。所有相关的集团公司只能根据本隐私政策使用您的个人信息。</li>
      <li>监管机构、司法机关和执法机构，以及出于安全、保障或遵守法律之目的的其他第三方。在一些情况下，我们依法须向当局披露您的信息，例如遵守法律义务或程序、强制实施我们的条款、处理与安全或欺诈相关的事宜，或者保护我们的用户。为遵守有效的法律程序条款，如传票、法院命令或搜查令，我们可能在获得或未获得您同意的情况下做出这些披露。一般而言，法律程序的条款禁止我们通知您任何此类披露。如果政府实体未提供所需的传票、法院命令或搜查令，则我们可能会征求您的同意，以按照政府实体的要求披露信息。我们还可能出于以下目的披露您的信息：
        <ul>
          <li>强制实施我们的条款和条件及其他协议，包括调查任何可能违反这些文件的行为；</li>
          <li>发现、防止或以其他方式解决安全、欺诈或技术问题；</li>
          <li>在法律要求或允许的情况下，保护我们、我们的用户、第三方或公众的权利、财产或安全（为了防止欺诈和降低信用风险而与其他公司和机构交换信息）。</li>
        </ul>
      </li>
      <li>全部或部分收购我们或我们的业务的第三方。如果出现任意下述情况，我们也可能会向第三方披露您的个人信息：
        <ul>
          <li>我们出售、转让、合并、整合或重组业务中的任何部分，或与任何其他企业合并、收购任何其他企业或与其组建合资企业，则我们可能会将您的数据披露给任何新所有者或其他参与我们业务变更的第三方；</li>
          <li>我们出售或转让我们的任何资产，则我们持有的与您有关的信息可能会作为该等资产的一部分出售，并可能会转让给任何新所有者或其他参与该等出售或转让的第三方。</li>
        </ul>
      </li>
    </ol>

    <h1>信息安全</h1>
    <p>无论您的个人信息存储在何处，我们均承诺维护其隐私和完整性。我们的信息安全与访问政策限制对我们的系统和技术进行访问，我们通过使用加密等技术保护措施来保护数据。</p>
    <p>遗憾的是，尽管我们已实施并保持合理措施来保护您的个人信息，通过互联网传输信息并不完全安全。若发生个人信息泄露等安全事件，我们会启动应急预案，阻止安全事件扩大，并以推送通知、公告等形式告知您。</p>

    <h1>您的权利</h1>
    <ol>
      <li>访问、更正、删除：您可以访问、更正或请求删除您的个人信息。</li>
      <li>撤销同意：在任何时候，您都可以撤回之前给予的同意，但这不会影响之前基于您的同意进行的个人信息处理。</li>
      <li>投诉：您有权向数据保护机构投诉我们的隐私实践。</li>
    </ol>

    <h1>儿童信息</h1>
    <ol>
      <li>儿童不得出于任何目的使用本网页，除非父母或监护人已提供同意。我们所指的儿童为18周岁以下的用户。</li>
      <li>我们不会出于任何目的故意收集儿童的个人信息。如果您认为我们在未经父母/监护人同意的情况下拥有儿童的个人信息，或者您是用户的父母或监护人并希望撤回同意，请与我们联系，我们将会删除此类信息。</li>
    </ol>

    <h1>第三方网站和服务</h1>
    <p>我们的服务可能包含第三方网站链接或服务（包括广告和外部服务）。您的信息由第三方处理的行为将适用该第三方的隐私政策，我们不对第三方的隐私和数据处理实践承担责任。</p>

    <h1>国际数据传输</h1>
    <p>为确保流畅的浏览体验，您可能会收到来自宠悦（PetJoy）及其合作伙伴外部的第三方（下文简称“第三方”）提供的内容或网络链接。开发组对此类第三方无控制权。您可选择是否访问第三方提供的链接、内容、产品和服务。</p>
    <p>开发组无法控制第三方的隐私和数据保护政策，此类第三方不受到本政策的约束。在向第三方提交个人信息之前，请参见这些第三方的隐私保护政策。</p>

    <h1>如何联系我们</h1>
    <p>如有任何关于本政策的问题或疑问，请通过联系我们。</p>
    <p>使用开发组的服务即表示您理解并同意本隐私政策的条款。我们承诺持续保护您的个人信息，并提供安全、可靠的服务环境。</p>

    <p style='text-align: right'>宠悦 | PetJoy 项目开发组</p>
    <p style='text-align: right'>2024 年 7 月 8 日</p>
  </el-container>
</template>

<style scoped>
@import '../styles/FooterNavbarTextCSS.css';
</style>
