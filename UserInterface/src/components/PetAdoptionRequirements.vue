<!--
  Project Name:  UserInterface
  File Name:     PetAdoptionRequirements.vue
  File Function: 宠物领养条件组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-27
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <!--德语版本-->
  <el-container class='page-container' direction='vertical' v-if="$i18n.locale == 'de'">
    <h1>Bedingungen für die Haustieradoption</h1>
    <p>Sehr geehrter Adoptionsbewerber, vielen Dank, dass Sie in Erwägung ziehen, einem Tier aus unserem Tierheim ein liebevolles Zuhause zu bieten. Bevor Sie ein Haustier offiziell adoptieren, möchten wir sicherstellen, dass Sie die folgenden Adoptionsbedingungen verstehen und akzeptieren, um gemeinsam die bestmögliche Umgebung für das Tier zu schaffen. Bitte lesen Sie die folgenden Bedingungen sorgfältig durch:</p>

    <h2>Alter und Identitätsprüfung</h2>
    <p>Adoptierende müssen mindestens 18 Jahre alt sein und über einen gültigen Ausweis verfügen, der bestätigt, dass Sie voll geschäftsfähig sind.</p>

    <h2>Wohnumgebung</h2>
    <p>Adoptierende müssen eine sichere, hygienische und komfortable Wohnumgebung bieten. Wenn Sie zur Miete wohnen, müssen Sie eine schriftliche Genehmigung des Vermieters vorlegen, die bestätigt, dass Haustiere erlaubt sind.</p>
    <p>Für Hunde empfehlen wir einen eingezäunten Außenbereich, um sicherzustellen, dass sie genügend Bewegungsfreiheit und eine sichere Umgebung haben.</p>
    <p>Für Katzen stellen Sie sicher, dass Ihr Zuhause geeignete Schutzmaßnahmen getroffen hat, um zu verhindern, dass Katzen durch Fenster oder Balkone entkommen.</p>

    <h2>Finanzielle Fähigkeiten</h2>
    <p>Adoptierende sollten über eine stabile Arbeit oder Einkommensquelle verfügen, um die täglichen Ausgaben für das Haustier zu tragen, einschließlich, aber nicht beschränkt auf Futter, regelmäßige tierärztliche Untersuchungen, Impfungen, Parasitenprävention, Kastrationsoperationen und mögliche Notfallkosten.</p>

    <h2>Zustimmung der Familienmitglieder</h2>
    <p>Alle Familienmitglieder, insbesondere Kinder, müssen der Adoption zustimmen und bereit sein, sich an der Pflege des Haustiers zu beteiligen. Stellen Sie sicher, dass niemand in Ihrem Haushalt allergisch gegen Haustiere ist.</p>

    <h2>Zeit und Energie</h2>
    <p>Adoptierende müssen sich verpflichten, die notwendige Zeit und Energie für die tägliche Pflege, regelmäßige Ausbildung, Sozialisierung und Krankheitsprävention des Haustiers aufzuwenden.</p>

    <h2>Gesetze und Gemeindevorschriften</h2>
    <p>Adoptierende müssen die örtlichen Gesetze und Vorschriften in Bezug auf Haustiere einhalten, einschließlich, aber nicht beschränkt auf Haustierregistrierung, Leinenpflicht, Lärmkontrolle und Rassenspezifische Einschränkungen.</p>

    <h2>Bildung und Training</h2>
    <p>Adoptierende sollten über grundlegende Kenntnisse der Haustierpflege verfügen oder bereit sein, an unseren angebotenen Haustierpflegekursen teilzunehmen, um besser zu verstehen, wie sie sich um ihren neuen Begleiter kümmern können.</p>

    <h2>Einhaltung des Adoptionsvertrages</h2>
    <p>Adoptierende müssen unseren Adoptionsvertrag unterzeichnen, der spezifische Adoptionsregeln, Verantwortlichkeiten und Tierschutzstandards enthält.</p>

    <h2>Nachverfolgung</h2>
    <p>Wir werden im ersten Jahr nach der Adoption gelegentliche Telefon- oder Hausbesuche durchführen, um sicherzustellen, dass es dem Tier gut geht und es glücklich ist.</p>

    <h2>Notfallplan</h2>
    <p>Adoptierende sollten einen Notfallplan haben, um auf mögliche unvorhergesehene Situationen vorbereitet zu sein und sicherzustellen, dass das Haustier in jedem Fall gut versorgt wird.</p>

    <p>Wir verstehen, dass die Adoption eines Haustiers eine wichtige Entscheidung ist, und daher verlangen wir von den Adoptierenden, im Bewerbungsprozess wahrheitsgemäße Angaben zu machen und bereit zu sein, die notwendigen Bewertungs- und Überprüfungsverfahren zu durchlaufen. Wir sind bestrebt, für jedes Tier das am besten geeignete Zuhause zu finden, und hoffen gleichzeitig, dass die Adoptierenden die wunderbare Zeit mit ihrem neuen Haustier genießen werden.</p>
    <p>Vielen Dank nochmals für Ihr Verständnis und Ihre Unterstützung!</p>
  </el-container>

  <!--英语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'en'">
    <h1>Pet Adoption Requirements</h1>
    <p>Dear Applicant for Adoption, thank you for considering a loving home for our shelter animals. Before you officially adopt a pet, we want to make sure that you understand and agree to the following adoption conditions, which will help us together create the most appropriate environment for the pet. Please read each of the following conditions carefully:</p>

    <h2>Age and identity verification</h2>
    <p>Adopters must be at least 18 years old and have a valid ID that proves you have full civil capacity.</p>

    <h2>Living environment</h2>
    <p>Adopters should provide a safe, hygienic and comfortable living environment. If you rent a house, you must submit written proof that the landlord agrees to keep the pet.</p>
    <p> For dogs, we recommend that you have a fenced outdoor space to ensure they have adequate range and a safe environment.</p>
    <p>For cats, verify that your home has the proper safeguards in place to prevent cats from escaping through Windows or balconies.</p>

    <h2>Financial ability</h2>
    <p>The adopter should have a stable job or source of income and be able to cover the expenses of daily living for the pet, including but not limited to food, regular veterinary visits, vaccinations, anti-parasite medications, spaying or neutering, and possible medical emergencies.</p>

    <h2>Consent from family members</h2>
    <p>All family members, especially children, need to agree and be willing to participate in the pet's care. Make sure no one in the family is allergic to pets.</p>

    <h2>Time and effort</h2>
    <p>The adopter must commit the necessary time and effort to the pet's daily care, regular training, socialization, and disease prevention.</p>

    <h2>Laws and community regulations</h2>
    <p>Adopters must comply with local pet laws and regulations, including but not limited to pet registration, leash use, noise control and breed specific restrictions.</p>

    <h2>Education and training</h2>
    <p>Adopters should have basic pet care knowledge or be willing to attend one of the pet care training courses we offer to better understand how to care for your new partner.</p>

    <h2>Follow the adoption agreement</h2>
    <p>Adopters are required to sign our adoption Agreement, which contains specific adoption rules, responsibilities, and pet welfare standards.</p>

    <h2>Follow up</h2>
    <p>We will make occasional return visits by phone or home visit for up to a year after adoption to confirm the health and well-being of the pet.</p>

    <h2>Plan for emergencies</h2>
    <p>The adopter should prepare an emergency plan for possible contingencies and ensure that the pet is properly cared for under any circumstances.</p>

    <p>We understand that adopting a pet is a big decision, so we ask that the adopter provide truthful information during the application process and be willing to cooperate with us through the necessary assessment and review process. We are committed to finding the best home for each pet, and we want owners to experience the quality of their time with their pets.</p>
    <p>Thank you again for your understanding and support!</p>
  </el-container>

  <!--西班牙语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'es'">
    <h1>Condiciones para la adopción de mascotas</h1>
    <p>Estimado solicitante de adopción, gracias por considerar ofrecer un hogar cálido a un animal de nuestro refugio. Antes de adoptar oficialmente una mascota, queremos asegurarnos de que entiende y acepta las siguientes condiciones de adopción, lo que nos ayudará a crear el mejor ambiente posible para la mascota. Por favor, lea cuidadosamente las siguientes condiciones:</p>

    <h2>Edad y verificación de identidad</h2>
    <p>Los adoptantes deben tener al menos 18 años de edad y poseer una identificación válida que demuestre su plena capacidad civil.</p>

    <h2>Entorno residencial</h2>
    <p>Los adoptantes deben proporcionar un entorno residencial seguro, higiénico y cómodo. Si vive en una casa alquilada, debe presentar un permiso por escrito del propietario que autorice la tenencia de mascotas.</p>
    <p>Para los perros, recomendamos tener un espacio exterior cercado para asegurar que tengan suficiente espacio para moverse y un entorno seguro.</p>
    <p>Para los gatos, asegúrese de que su hogar tenga medidas de protección adecuadas para evitar que los gatos escapen por ventanas o balcones.</p>

    <h2>Capacidad económica</h2>
    <p>Los adoptantes deben tener un trabajo estable o una fuente de ingresos que les permita cubrir los gastos diarios de la mascota, incluyendo, pero no limitándose a, alimentos, chequeos veterinarios regulares, vacunaciones, medicamentos preventivos para parásitos, esterilización y posibles gastos de emergencia médica.</p>

    <h2>Consentimiento de los miembros del hogar</h2>
    <p>Todos los miembros del hogar, especialmente los niños, deben estar de acuerdo con la adopción y estar dispuestos a participar en el cuidado de la mascota. Asegúrese de que nadie en su hogar sea alérgico a las mascotas.</p>

    <h2>Tiempo y energía</h2>
    <p>Los adoptantes deben comprometerse a dedicar el tiempo y la energía necesarios para el cuidado diario, el entrenamiento regular, la socialización y la prevención de enfermedades de la mascota.</p>

    <h2>Leyes y regulaciones comunitarias</h2>
    <p>Los adoptantes deben cumplir con las leyes y regulaciones locales relacionadas con las mascotas, incluyendo, pero no limitándose a, el registro de mascotas, el uso de correas, el control de ruido y las restricciones específicas de ciertas razas.</p>

    <h2>Educación y formación</h2>
    <p>Los adoptantes deben tener conocimientos básicos sobre el cuidado de mascotas o estar dispuestos a asistir a los cursos de formación sobre cuidado de mascotas que ofrecemos para entender mejor cómo cuidar a su nuevo compañero.</p>

    <h2>Cumplimiento del acuerdo de adopción</h2>
    <p>Los adoptantes deben firmar nuestro acuerdo de adopción, que incluye reglas específicas de adopción, responsabilidades y estándares de bienestar animal.</p>

    <h2>Seguimiento posterior</h2>
    <p>Realizaremos visitas telefónicas o domiciliarias ocasionales durante el primer año después de la adopción para asegurarnos de que la mascota esté sana y feliz.</p>

    <h2>Plan de emergencia</h2>
    <p>Los adoptantes deben tener un plan de emergencia preparado para hacer frente a posibles situaciones imprevistas y asegurarse de que la mascota esté bien cuidada en cualquier circunstancia.</p>

    <p>Entendemos que adoptar una mascota es una decisión importante, por lo que requerimos que los adoptantes proporcionen información veraz durante el proceso de solicitud y estén dispuestos a cooperar con nosotros para completar los procedimientos necesarios de evaluación y revisión. Nos comprometemos a encontrar el hogar más adecuado para cada mascota y esperamos que los adoptantes disfruten de la maravillosa experiencia de tener una mascota.</p>
    <p>¡Gracias nuevamente por su comprensión y apoyo!</p>
  </el-container>

  <!--法语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'fr'">
    <h1>Conditions d'adoption d'animaux de compagnie</h1>
    <p>Cher demandeur d'adoption, merci de considérer offrir un foyer chaleureux à un animal de notre refuge. Avant d'adopter officiellement un animal de compagnie, nous voulons nous assurer que vous comprenez et acceptez les conditions d'adoption suivantes, ce qui nous aidera à créer ensemble le meilleur environnement possible pour l'animal. Veuillez lire attentivement les conditions suivantes :</p>

    <h2>Âge et vérification d'identité</h2>
    <p>Les adoptants doivent avoir au moins 18 ans et posséder une pièce d'identité valide prouvant leur pleine capacité juridique.</p>

    <h2>Environnement résidentiel</h2>
    <p>Les adoptants doivent fournir un environnement résidentiel sûr, hygiénique et confortable. Si vous vivez en location, vous devez fournir une autorisation écrite de votre propriétaire permettant la présence d'animaux de compagnie.</p>
    <p>Pour les chiens, nous recommandons un espace extérieur clôturé pour s'assurer qu'ils disposent de suffisamment d'espace pour bouger et d'un environnement sûr.</p>
    <p>Pour les chats, assurez-vous que votre maison est dotée de mesures de protection appropriées pour éviter que les chats ne s'échappent par les fenêtres ou les balcons.</p>

    <h2>Capacité financière</h2>
    <p>Les adoptants doivent avoir un emploi stable ou une source de revenus suffisante pour couvrir les dépenses quotidiennes de l'animal, y compris, mais sans s'y limiter, la nourriture, les examens vétérinaires réguliers, les vaccinations, les médicaments préventifs contre les parasites, la stérilisation et les éventuels frais médicaux d'urgence.</p>

    <h2>Consentement des membres de la famille</h2>
    <p>Tous les membres de la famille, en particulier les enfants, doivent être d'accord avec l'adoption et être prêts à participer aux soins de l'animal. Assurez-vous qu'aucun membre de votre foyer n'est allergique aux animaux de compagnie.</p>

    <h2>Temps et énergie</h2>
    <p>Les adoptants doivent s'engager à consacrer le temps et l'énergie nécessaires aux soins quotidiens, à l'éducation régulière, à la socialisation et à la prévention des maladies de l'animal.</p>

    <h2>Législation et réglementations locales</h2>
    <p>Les adoptants doivent respecter les lois et réglementations locales en matière d'animaux de compagnie, y compris, mais sans s'y limiter, l'enregistrement des animaux, l'utilisation de la laisse, le contrôle du bruit et les restrictions spécifiques à certaines races.</p>

    <h2>Éducation et formation</h2>
    <p>Les adoptants doivent avoir des connaissances de base en matière de soins aux animaux ou être disposés à suivre les cours de formation que nous proposons pour mieux comprendre comment s'occuper de leur nouveau compagnon.</p>

    <h2>Respect du contrat d'adoption</h2>
    <p>Les adoptants doivent signer notre contrat d'adoption, qui comprend des règles spécifiques, des responsabilités et des normes de bien-être animal.</p>

    <h2>Suivi post-adoption</h2>
    <p>Nous effectuerons des visites téléphoniques ou à domicile occasionnelles pendant la première année suivant l'adoption pour nous assurer que l'animal est en bonne santé et heureux.</p>

    <h2>Plan d'urgence</h2>
    <p>Les adoptants doivent avoir un plan d'urgence prêt à faire face aux situations imprévues et s'assurer que l'animal est bien pris en charge en toutes circonstances.</p>

    <p>Nous comprenons que l'adoption d'un animal de compagnie est une décision importante, et c'est pourquoi nous demandons aux adoptants de fournir des informations véridiques tout au long du processus de candidature et d'être prêts à coopérer avec nous pour compléter les procédures nécessaires d'évaluation et de vérification. Nous nous engageons à trouver le foyer le plus approprié pour chaque animal, et nous espérons que les adoptants apprécieront le merveilleux moment passé avec leur nouvel animal de compagnie.</p>
    <p>Merci encore pour votre compréhension et votre soutien !</p>
  </el-container>

  <!--意大利语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'it'">
    <h1>Condizioni per l'adozione di animali domestici</h1>
    <p>Gentile richiedente l'adozione, grazie per aver considerato di fornire una casa amorevole agli animali nel nostro rifugio. Prima di adottare ufficialmente un animale domestico, vogliamo assicurarci che tu comprenda e accetti le seguenti condizioni di adozione, che ci aiuteranno a lavorare insieme per creare l'ambiente più appropriato per il tuo animale domestico. Si prega di leggere attentamente le seguenti condizioni:</p>

    <h2>Verifica dell'età e dell'identità</h2>
    <p>L'adottante deve avere più di 18 anni ed essere munito di un documento di identità valido che attesti la piena capacità civile.</p>

    <h2>Ambiente di vita</h2>
    <p>Gli adottanti devono fornire un ambiente di vita sicuro, igienico e confortevole. Se affitti, devi presentare una prova scritta che il proprietario accetta di tenere animali domestici.</p>
    <p>Per i cani, consigliamo di disporre di uno spazio esterno recintato per garantire loro un raggio d'azione adeguato e un ambiente sicuro.</p>
    <p>Per quanto riguarda i gatti, assicurati che la tua casa sia adeguatamente protetta per evitare che fuggano attraverso finestre o balconi.</p>

    <h2>Capacità economica</h2>
    <p>L'adottante dovrebbe avere un lavoro stabile o una fonte di reddito ed essere in grado di sostenere le spese quotidiane dell'animale, inclusi ma non limitati a cibo, esami veterinari regolari, vaccinazioni, farmaci per la prevenzione dei parassiti, interventi chirurgici di castrazione ed eventuali spese di emergenza medica.</p>

    <h2>I membri della famiglia sono d'accordo</h2>
    <p>Tutti i membri della famiglia, soprattutto i bambini, devono essere d'accordo ed essere disposti a partecipare alla cura dell'animale. Assicurati che nessuno in casa sia allergico agli animali domestici.</p>

    <h2>Tempo ed energia</h2>
    <p>Gli adottanti devono impegnarsi a investire il tempo e le energie necessarie per la cura quotidiana dell'animale, l'addestramento regolare, la socializzazione e la prevenzione delle malattie.</p>

    <h2>Leggi e regolamenti comunitari</h2>
    <p>Gli adottanti devono rispettare le leggi e i regolamenti relativi agli animali domestici nella loro zona, inclusi ma non limitati alla registrazione degli animali domestici, all'uso del guinzaglio, al controllo del rumore e alle restrizioni specifiche per razza.</p>

    <h2>Istruzione e formazione</h2>
    <p>Gli adottanti dovrebbero avere una conoscenza di base sulla cura degli animali domestici o essere disposti a frequentare i corsi di formazione sulla cura degli animali che offriamo per comprendere meglio come prendersi cura del proprio nuovo compagno.</p>

    <h2>Rispettare l'accordo di adozione</h2>
    <p>Gli adottanti sono tenuti a firmare il nostro Contratto di adozione, che contiene regole di adozione, responsabilità e standard specifici sul benessere degli animali domestici.</p>

    <h2>Seguito</h2>
    <p>Effettueremo telefonate occasionali o visite a domicilio entro un anno dall'adozione per confermare la salute e la felicità dell'animale.</p>

    <h2>Piano di emergenza</h2>
    <p>Gli adottanti dovrebbero preparare un piano di emergenza per affrontare possibili emergenze e garantire che l'animale sia ben curato in ogni situazione.</p>

    <p>Comprendiamo che adottare un animale domestico è una decisione importante, quindi richiediamo agli adottanti di fornire informazioni veritiere durante il processo di richiesta e di essere disposti a collaborare con noi per completare il necessario processo di valutazione e revisione. Ci impegniamo a trovare la casa migliore per ogni animale domestico e speriamo anche che gli adottanti possano trascorrere momenti meravigliosi con il loro animale domestico.</p>
    <p>Grazie ancora per la comprensione e il supporto!</p>
  </el-container>

  <!--日语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'ja'">
    <h1>ペットの養子縁組条件</h1>
    <p>尊敬なる養子申請者の皆様、私たちのシェルターの動物に温かい家を提供してくださることを検討していただき、ありがとうございます。正式にペットを養子にする前に、以下の養子条件を理解し、同意していただけることを確認したいと思います。これは、ペットに最適な環境を一緒に作り出すのに役立ちます。以下の条件をよくお読みください：</p>

    <h2>年齢と身分証明</h2>
    <p>養子希望者は18歳以上であり、有効な身分証明書を持っていることが必要です。これは、完全な民事行為能力を証明するものです。</p>

    <h2>住環境</h2>
    <p>養子希望者は、安全で衛生的かつ快適な住環境を提供する必要があります。賃貸住宅に住んでいる場合、ペットの飼育を許可する家主の書面による同意を提出する必要があります。</p>
    <p>犬の場合、十分な運動範囲と安全な環境を確保するために、囲いのある屋外スペースを持つことをお勧めします。</p>
    <p>猫の場合、窓やバルコニーからの脱走を防ぐために、適切な保護対策が取られていることを確認してください。</p>

    <h2>経済的能力</h2>
    <p>養子希望者は、安定した仕事または収入源を持ち、ペットの日常生活の費用を負担できる能力があることが必要です。これには、食事、定期的な獣医の検査、予防接種、寄生虫予防薬、避妊手術、そして可能な医療緊急費用が含まれます。</p>

    <h2>家族の同意</h2>
    <p>特に子供を含むすべての家族が、ペットの世話に参加することに同意し、喜んで参加することが必要です。家の中にペットアレルギーがないことを確認してください。</p>

    <h2>時間とエネルギー</h2>
    <p>養子希望者は、ペットの日常的な世話、定期的な訓練、社会化、病気の予防に必要な時間とエネルギーを投入することを約束しなければなりません。</p>

    <h2>法律とコミュニティの規則</h2>
    <p>養子希望者は、ペットの登録、リードの使用、騒音の管理、特定の品種の制限など、居住地域のペット関連の法律や規則を遵守しなければなりません。</p>

    <h2>教育と訓練</h2>
    <p>養子希望者は、基本的なペットケアの知識を持っているか、または私たちが提供するペットケアトレーニングコースに参加する意欲を持っている必要があります。これにより、新しいパートナーの世話をよりよく理解することができます。</p>

    <h2>養子契約の遵守</h2>
    <p>養子希望者は、具体的な養子規則、責任、およびペットの福祉基準を含む養子契約に署名しなければなりません。</p>

    <h2>追跡</h2>
    <p>私たちは、養子縁組後の1年間、不定期に電話または家庭訪問を行い、ペットの健康と幸福を確認します。</p>

    <h2>緊急計画</h2>
    <p>養子希望者は、突発的な事態に備えた緊急計画を準備し、どのような状況でもペットが適切に世話されるようにする必要があります。</p>

    <p>ペットを養子にすることは重大な決断であると理解していますので、申請過程で正確な情報を提供し、必要な評価と審査の手続きを完了するために協力する意欲があることを求めます。私たちは、すべてのペットに最も適した家を見つけることを目指しており、養子希望者が新しいペットとの素晴らしい時間を体験できることを願っています。</p>
    <p>ご理解とご支援に改めて感謝いたします！</p>
  </el-container>

  <!--韩语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'ko'">
    <h1>반려동물 입양 조건</h1>
    <p>존경하는 입양 신청자님, 저희 보호소의 동물에게 따뜻한 가정을 제공해 주셔서 감사합니다. 공식적으로 애완동물을 입양하기 전에, 다음 입양 조건을 이해하고 동의해 주시기 바랍니다. 이는 우리가 함께 애완동물에게 가장 적합한 환경을 만들어주는 데 도움이 됩니다. 다음 조건을 주의 깊게 읽어주세요:</p>

    <h2>나이 및 신분 확인</h2>
    <p>입양자는 만 18세 이상이어야 하며, 유효한 신분증을 소지하여 완전한 민사행위 능력을 증명해야 합니다.</p>

    <h2>거주 환경</h2>
    <p>입양자는 안전하고 위생적이며 편안한 거주 환경을 제공해야 합니다. 임대 주택에 거주하는 경우, 집주인의 애완동물 허용 서면 동의를 제출해야 합니다.</p>
    <p>개를 위해서는 충분한 활동 범위와 안전한 환경을 보장하기 위해 울타리가 있는 야외 공간을 갖추는 것이 좋습니다.</p>
    <p>고양이를 위해서는 창문이나 발코니에서 탈출하지 않도록 적절한 보호 조치를 취했는지 확인해야 합니다.</p>

    <h2>경제적 능력</h2>
    <p>입양자는 안정적인 직업 또는 수입원을 가지고 있어야 하며, 애완동물의 일상 생활 비용을 감당할 수 있어야 합니다. 여기에는 식비, 정기적인 수의사 검진, 예방 접종, 기생충 예방 약물, 중성화 수술 및 가능한 의료 응급 비용이 포함됩니다.</p>

    <h2>가족 구성원의 동의</h2>
    <p>모든 가족 구성원, 특히 어린이는 입양에 동의하고 애완동물의 돌봄에 참여할 의지가 있어야 합니다. 가족 중 누구도 애완동물에 알레르기가 없는지 확인해 주세요.</p>

    <h2>시간과 에너지</h2>
    <p>입양자는 애완동물의 일상적인 돌봄, 정기적인 훈련, 사회화 및 질병 예방에 필요한 시간과 에너지를 투입할 것을 약속해야 합니다.</p>

    <h2>법률 및 지역 규정</h2>
    <p>입양자는 애완동물 등록, 리드 사용, 소음 관리 및 특정 품종 제한 등 거주 지역의 애완동물 관련 법률 및 규정을 준수해야 합니다.</p>

    <h2>교육 및 훈련</h2>
    <p>입양자는 기본적인 애완동물 돌봄 지식을 갖추고 있거나, 저희가 제공하는 애완동물 돌봄 교육 과정을 수강할 의지가 있어야 합니다. 이를 통해 새로운 반려동물을 더 잘 돌볼 수 있습니다.</p>

    <h2>입양 계약 준수</h2>
    <p>입양자는 구체적인 입양 규칙, 책임 및 애완동물 복지 기준을 포함하는 입양 계약에 서명해야 합니다.</p>

    <h2>후속 관리</h2>
    <p>저희는 입양 후 1년 동안 불규칙하게 전화 또는 가정 방문을 통해 애완동물의 건강과 행복 상태를 확인할 것입니다.</p>

    <h2>비상 계획</h2>
    <p>입양자는 비상 상황에 대비한 비상 계획을 준비하고, 어떤 상황에서도 애완동물이 적절히 돌봄 받을 수 있도록 해야 합니다.</p>

    <p>애완동물을 입양하는 것은 중요한 결정이라는 것을 이해하고 있으므로, 입양자는 신청 과정에서 진실한 정보를 제공하고 필요한 평가 및 심사 절차를 완료하는 데 협조할 의지를 가져야 합니다. 저희는 모든 애완동물에게 가장 적합한 가정을 찾기 위해 최선을 다하고 있으며, 입양자가 새로운 애완동물과 함께하는 멋진 시간을 즐기기를 바랍니다.</p>
    <p>다시 한번 이해와 지원에 감사드립니다!</p>
  </el-container>

  <!--葡萄牙语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'pt'">
    <h1>Condições para adoção de animais de estimação</h1>
    <p>Caro candidato à adoção, obrigado por considerar oferecer um lar acolhedor a um animal do nosso abrigo. Antes de adotar oficialmente um animal de estimação, queremos garantir que você compreenda e concorde com as seguintes condições de adoção, que nos ajudarão a criar juntos o ambiente mais adequado para o animal. Por favor, leia atentamente as condições a seguir:</p>

    <h2>Idade e verificação de identidade</h2>
    <p>Os adotantes devem ter pelo menos 18 anos e possuir um documento de identificação válido que comprove sua capacidade civil completa.</p>

    <h2>Ambiente residencial</h2>
    <p>Os adotantes devem fornecer um ambiente residencial seguro, higiênico e confortável. Se você mora em uma casa alugada, deve apresentar uma autorização por escrito do proprietário permitindo animais de estimação.</p>
    <p>Para cães, recomendamos ter um espaço externo cercado para garantir que eles tenham espaço suficiente para se movimentar e um ambiente seguro.</p>
    <p>Para gatos, certifique-se de que sua casa tenha medidas de proteção adequadas para evitar que os gatos escapem pelas janelas ou varandas.</p>

    <h2>Capacidade financeira</h2>
    <p>Os adotantes devem ter um emprego estável ou uma fonte de renda que lhes permita arcar com as despesas diárias do animal de estimação, incluindo, mas não se limitando a, alimentação, exames veterinários regulares, vacinação, medicamentos preventivos contra parasitas, castração e possíveis despesas médicas de emergência.</p>

    <h2>Consentimento dos membros da família</h2>
    <p>Todos os membros da família, especialmente as crianças, devem concordar com a adoção e estar dispostos a participar dos cuidados com o animal de estimação. Certifique-se de que ninguém em sua casa seja alérgico a animais de estimação.</p>

    <h2>Tempo e energia</h2>
    <p>Os adotantes devem se comprometer a dedicar o tempo e a energia necessários para os cuidados diários, treinamento regular, socialização e prevenção de doenças do animal de estimação.</p>

    <h2>Leis e regulamentos comunitários</h2>
    <p>Os adotantes devem cumprir as leis e regulamentos locais relacionados a animais de estimação, incluindo, mas não se limitando a, registro de animais, uso de coleiras, controle de ruído e restrições específicas de certas raças.</p>

    <h2>Educação e treinamento</h2>
    <p>Os adotantes devem ter conhecimentos básicos sobre cuidados com animais de estimação ou estar dispostos a participar dos cursos de treinamento sobre cuidados com animais de estimação que oferecemos, para entender melhor como cuidar de seu novo companheiro.</p>

    <h2>Cumprimento do contrato de adoção</h2>
    <p>Os adotantes devem assinar nosso contrato de adoção, que inclui regras específicas de adoção, responsabilidades e padrões de bem-estar animal.</p>

    <h2>Acompanhamento posterior</h2>
    <p>Realizaremos visitas telefônicas ou domiciliares ocasionais durante o primeiro ano após a adoção para garantir que o animal esteja saudável e feliz.</p>

    <h2>Plano de emergência</h2>
    <p>Os adotantes devem ter um plano de emergência preparado para lidar com possíveis situações imprevistas e garantir que o animal de estimação seja bem cuidado em qualquer circunstância.</p>

    <p>Entendemos que a adoção de um animal de estimação é uma decisão importante, por isso exigimos que os adotantes forneçam informações verdadeiras durante o processo de candidatura e estejam dispostos a cooperar conosco para completar os procedimentos necessários de avaliação e revisão. Estamos empenhados em encontrar o lar mais adequado para cada animal e esperamos que os adotantes apreciem o maravilhoso tempo com seu novo animal de estimação.</p>
    <p>Mais uma vez, agradecemos pela sua compreensão e apoio!</p>
  </el-container>

  <!--俄语版本-->
  <el-container class='page-container' direction='vertical' v-else-if="$i18n.locale == 'ru'">
    <h1>Условия усыновления домашних животных</h1>
    <p>Уважаемый заявитель на усыновление, спасибо за ваше желание предоставить теплый дом животному из нашего приюта. Прежде чем вы официально усыновите питомца, мы хотим убедиться, что вы понимаете и соглашаетесь с нижеизложенными условиями усыновления, которые помогут нам совместно создать наиболее подходящую среду для питомца. Пожалуйста, внимательно прочитайте следующие условия:</p>

    <h2>Возраст и проверка личности</h2>
    <p>Усыновители должны быть не моложе 18 лет и иметь действительный документ, удостоверяющий личность, подтверждающий их полную гражданскую дееспособность.</p>

    <h2>Жилищные условия</h2>
    <p>Усыновители должны обеспечить безопасные, гигиеничные и комфортные жилищные условия. Если вы живете в арендованной квартире, необходимо предоставить письменное согласие арендодателя на содержание животных.</p>
    <p>Для собак рекомендуется наличие огороженного открытого пространства, чтобы обеспечить им достаточно места для движения и безопасную среду.</p>
    <p>Для кошек убедитесь, что в вашем доме приняты соответствующие меры предосторожности, чтобы предотвратить их побег через окна или балконы.</p>

    <h2>Финансовые возможности</h2>
    <p>Усыновители должны иметь стабильную работу или источник дохода, позволяющие покрывать повседневные расходы на содержание питомца, включая, но не ограничиваясь, питание, регулярные ветеринарные осмотры, вакцинацию, препараты для профилактики паразитов, стерилизацию и возможные неотложные медицинские расходы.</p>

    <h2>Согласие членов семьи</h2>
    <p>Все члены семьи, особенно дети, должны согласиться на усыновление и быть готовы участвовать в уходе за питомцем. Убедитесь, что никто в вашем доме не имеет аллергии на животных.</p>

    <h2>Время и усилия</h2>
    <p>Усыновители должны обязаться уделять необходимое время и усилия на повседневный уход, регулярные тренировки, социализацию и профилактику заболеваний питомца.</p>

    <h2>Законы и правила сообщества</h2>
    <p>Усыновители должны соблюдать местные законы и правила, касающиеся содержания животных, включая, но не ограничиваясь, регистрацию животных, использование поводков, контроль за шумом и ограничения по породам.</p>

    <h2>Образование и обучение</h2>
    <p>Усыновители должны обладать базовыми знаниями о уходе за животными или быть готовы пройти предлагаемые нами курсы по уходу за животными, чтобы лучше понять, как ухаживать за новым питомцем.</p>

    <h2>Соблюдение договора об усыновлении</h2>
    <p>Усыновители должны подписать наш договор об усыновлении, который включает конкретные правила усыновления, обязанности и стандарты благополучия животных.</p>

    <h2>Последующее наблюдение</h2>
    <p>Мы будем проводить случайные телефонные звонки или визиты на дом в течение первого года после усыновления, чтобы убедиться в здоровье и счастье питомца.</p>

    <h2>План на случай чрезвычайных ситуаций</h2>
    <p>Усыновители должны иметь план на случай чрезвычайных ситуаций, чтобы быть готовыми к возможным непредвиденным ситуациям и обеспечить надлежащий уход за питомцем в любых обстоятельствах.</p>

    <p>Мы понимаем, что усыновление питомца — это важное решение, поэтому мы требуем от усыновителей предоставления достоверной информации в процессе подачи заявки и готовности сотрудничать с нами для завершения необходимых процедур оценки и проверки. Мы стремимся найти наиболее подходящий дом для каждого питомца и надеемся, что усыновители смогут насладиться прекрасным временем со своим новым питомцем.</p>
    <p>Еще раз благодарим за ваше понимание и поддержку!</p>
  </el-container>

  <!--汉语（默认语言）版本-->
  <el-container class='page-container' direction='vertical' v-else>
    <h1>宠物领养条件</h1>
    <p>尊敬的领养申请人，感谢您考虑为我们收容所中的动物提供一个温馨的家。在您正式领养宠物之前，我们想确保您理解并同意以下领养条件，这有助于我们共同为宠物创造一个最合适的环境。请仔细阅读以下各项条件：</p>

    <h2>年龄与身份验证</h2>
    <p>领养者必须年满18周岁，且具有有效的身份证件，证明您有完全民事行为能力。</p>

    <h2>居住环境</h2>
    <p>领养者需提供一个安全、卫生、舒适的居住环境。如果您租房居住，必须提交房东同意养宠物的书面证明。</p>
    <p>对于狗，我们建议您有一个带围栏的室外空间，以确保它们有足够的活动范围和安全的环境。</p>
    <p>对于猫，确认您的家已采取适当的防护措施，避免猫儿从窗户或阳台逃出。</p>

    <h2>经济能力</h2>
    <p>领养者应有稳定的工作或收入来源，能够承担宠物日常生活的开销，包括但不限于食物、定期兽医检查、疫苗接种、预防寄生虫药物、绝育手术以及可能的医疗急救费用。</p>

    <h2>家庭成员同意</h2>
    <p>所有家庭成员，特别是儿童，需同意并愿意参与到宠物的照顾中来。确保家中无人对宠物过敏。</p>

    <h2>时间与精力</h2>
    <p>领养者必须承诺投入必要的时间和精力，用于宠物的日常照料、定期训练、社交化以及疾病预防。</p>

    <h2>法律与社区规定</h2>
    <p>领养者须遵守所在地区的宠物相关法律法规，包括但不限于宠物登记、牵引绳使用、噪音控制以及特定品种限制等。</p>

    <h2>教育与培训</h2>
    <p>领养者应具备基本的宠物护理知识，或愿意参加我们提供的宠物护理培训课程，以更好地了解如何照顾您的新伙伴。</p>

    <h2>遵守领养协议</h2>
    <p>领养者需签署我们的领养协议，其中包含具体的领养规则、责任以及宠物福利标准。</p>

    <h2>后续跟踪</h2>
    <p>我们将在领养后的一年内，不定期进行电话或家访回访，以确认宠物的健康和幸福状态。</p>

    <h2>应急计划</h2>
    <p>领养者应准备一个应急计划，以应对可能的突发情况，确保宠物在任何情况下都能得到妥善照顾。</p>

    <p>我们理解领养宠物是一个重大的决定，因此我们要求领养者在申请过程中提供真实的信息，并愿意配合我们完成必要的评估和审核流程。我们致力于为每一只宠物寻找最适合它们的家，同时也希望领养者能够体验到与宠物相伴的美好时光。</p>
    <p>再次感谢您的理解和支持！</p>
  </el-container>
</template>

<style scoped>
@import '../styles/PetAdoptionPageTextCSS.css';
</style>
