<!--
  Project Name:  UserInterface
  File Name:     CodeOfConduct.vue
  File Function: 行为准则组件
  Author:        宠悦 | PetJoy 项目开发组
  Update Date:   2024-07-26
  License:       Creative Commons Attribution 4.0 International License
-->

<template>
  <!--德语版本-->
  <el-container direction='vertical' v-if="$i18n.locale == 'de'">
    <p>Willkommen bei PetJoy, einer Plattform, die für Tierliebhaber konzipiert wurde, um Informationen auszutauschen und Ressourcen zu teilen. Um eine freundliche, gesunde und wertvolle Community-Umgebung zu pflegen, haben wir den folgenden Verhaltenskodex für alle Benutzer festgelegt:</p>

    <h1>Respekt und positive Kommunikation</h1>
    <p>Wir befürworten zivilisierte Kommunikation und untersagen strikt jegliche Form von persönlichen Angriffen, Beleidigungen oder bedrohlicher Rede. Bitte respektieren Sie jedes Mitglied und erhalten Sie Harmonie und Positivität im Online-Raum.</p>

    <h1>Originalität und Teilen</h1>
    <p>Wir ermutigen das Posten von originalem Inhalt und technischen Diskussionen. Teilen Sie Ihre Haustiergeschichten, Pflegewissen, Trainingstipps oder Informationen, die für die Gesundheit und das Glück der Tiere förderlich sind.</p>

    <h1>Qualität und Relevanz des Inhalts</h1>
    <p>Das Posten von wiederholtem Inhalt, Spam, themenfremden Beiträgen oder das Beteiligen an repetitivem Verhalten ist verboten. Stellen Sie sicher, dass Ihre Beiträge für die Community-Mitglieder wertvoll sind und sich auf das Haustierthema beziehen; nutzen Sie die entsprechenden Forenbereiche, um die organisatorische Klarheit zu wahren.</p>

    <h1>Rechtliche und ethische Standards</h1>
    <p>Das Posten von illegalen Inhalten ist absolut verboten, einschließlich, aber nicht beschränkt auf die Förderung illegaler Aktivitäten, piratierter Ressourcen, Urheberrechtsverletzungen oder der Verteilung illegaler persönlicher Informationen.</p>

    <h1>Soziale Verantwortung</h1>
    <p>Vermeiden Sie alle Inhalte, die Pornografie, Gewalt, Missbrauch oder etwas enthalten, das Unbehagen verursachen könnte. Erhalten Sie die Sauberkeit und Sicherheit der Online-Umgebung.</p>

    <h1>Politische Neutralität</h1>
    <p>Dieses Forum ist ein Zufluchtsort für Tierenthusiasten, frei von politischen Diskussionen, um die Gemeinschaftsharmonie und den Fokus zu wahren.</p>

    <h1>Standards für kommerzielles Verhalten</h1>
    <p>Unautorisierte kommerzielle Werbung und konkurrierende Promotionen sind verboten. Wenn Sie tierbezogene Produkte oder Dienstleistungen bewerben möchten, befolgen Sie bitte die Vorschriften der spezifischen Werbebereiche. Persönliche Transaktionen sollten sich an Prinzipien der Integrität halten, und die Funktion "Antwort nur für den Autor sichtbar" sollte nicht missbraucht werden, insbesondere von Benutzern mit geringem Beitrag.</p>

    <h1>Datenschutz</h1>
    <p>Respektieren Sie die Privatsphäre anderer; geben Sie ohne Erlaubnis keine persönlichen Informationen von jemandem preis, einschließlich Kontaktinformationen, Adressen usw.</p>

    <h1>Respekt vor dem Urheberrecht</h1>
    <p>Betonen Sie das Bewusstsein für das Urheberrecht; beim erneuten Posten von Inhalten immer den ursprünglichen Autor und die Quelle nennen und die Urheberrechtserklärung des Originalwerks einhalten.</p>

    <h1>Umgang mit Verstößen</h1>
    <p>Das Forum-Managementteam behält sich das endgültige Recht vor, Verstöße zu entscheiden, einschließlich, aber nicht beschränkt auf Bearbeitungen, Warnungen, Zugriffsbeschränkungen und sogar Kontosperrungen.</p>

    <h1>Berichtsbelohnungen und Strafen bei Missbrauch</h1>
    <p>Wir ermutigen Benutzer dazu, Verstöße zu melden; verifizierte Berichte führen zu Forum-Belohnungen für den Reporter. Gleichzeitig wird der Missbrauch des Berichtsmechanismus angemessen bestraft.</p>

    <h1>Benutzerinteraktion</h1>
    <p>Beteiligen Sie sich aktiv und engagieren Sie sich konstruktiv, um eine freundliche, gegenseitige Lern- und Austauschumgebung zu schaffen.</p>

    <p>Wir freuen uns darauf, dass jedes Mitglied von PetJoy Teil dieser warmen Familie wird, zusammenarbeitet, um das Wohlergehen der Tiere zu verbessern. Lasst uns gemeinsam ein mit Liebe und Wissen gefülltes Tierparadies schaffen!</p>

    <p style='text-align: right'>PetJoy Entwicklungsteam</p>
    <p style='text-align: right'>8. Juli 2024</p>
  </el-container>

  <!--英语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'en'">
    <p>Welcome to PetJoy, a platform designed for pet enthusiasts to exchange information and share resources. To maintain a friendly, healthy, and valuable community environment, we have established the following code of conduct for all users to abide by:</p>

    <h1>Respect and Positive Communication</h1>
    <p>We advocate civil communication and strictly prohibit any form of personal attacks, insults, or threatening speech. Please respect each member and maintain harmony and positivity in the online space.</p>

    <h1>Originality and Sharing</h1>
    <p>We encourage the posting of original content and technical discussions. Share your pet stories, care knowledge, training tips, or any information beneficial to pet health and happiness.</p>

    <h1>Content Quality and Relevance</h1>
    <p>Posting repetitive content, spam, off-topic posts, or engaging in repetitive behavior is prohibited. Ensure your posts are valuable to community members and relevant to the pet theme; use the appropriate forum sections to maintain organizational clarity.</p>

    <h1>Legal and Ethical Standards</h1>
    <p>Posting of illegal content is absolutely prohibited, including but not limited to promotion of illegal activities, pirated resources, copyright infringement, or distribution of illegal personal information.</p>

    <h1>Social Responsibility</h1>
    <p>Avoid all content that contains pornography, violence, abuse, or anything that may cause discomfort. Maintain the cleanliness and safety of the online environment.</p>

    <h1>Political Neutrality</h1>
    <p>This forum is a sanctuary for pet enthusiasts, free from political discussions to maintain community harmony and focus.</p>

    <h1>Standards for Commercial Behavior</h1>
    <p>Unauthorized commercial advertising and competitive promotions are prohibited. If you need to promote pet-related products or services, please follow the regulations of the specific advertising areas. Personal transactions should adhere to principles of integrity, and the "reply visible only to author" feature should not be abused, especially by low-contribution users.</p>

    <h1>Privacy Protection</h1>
    <p>Respect others' privacy; do not disclose anyone's personal information without permission, including contact information, addresses, etc.</p>

    <h1>Respect for Copyright</h1>
    <p>Emphasize copyright awareness; when reposting content, always credit the original author and source, and comply with the copyright declaration of the original work.</p>

    <h1>Violation Handling</h1>
    <p>The forum management team reserves the final right to adjudicate violations, including but not limited to editing, warnings, access restrictions, and even account bans.</p>

    <h1>Report Rewards and Abuse Penalties</h1>
    <p>We encourage users to report violations; verified reports will result in forum rewards for the reporter. At the same time, abuse of the reporting mechanism will be appropriately penalized.</p>

    <h1>User Interaction</h1>
    <p>Actively participate and constructively engage to create a friendly, mutual-help learning and exchange environment.</p>

    <p>We look forward to every member of PetJoy becoming part of this warm family, working together to enhance pet welfare. Let us join hands to create a pet paradise filled with love and knowledge!</p>

    <p style='text-align: right'>PetJoy Development Team</p>
    <p style='text-align: right'>8 July 2024</p>
  </el-container>

  <!--西班牙语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'es'">
    <p>Bienvenido a PetJoy, una plataforma diseñada para que los entusiastas de las mascotas intercambien información y compartan recursos. Para mantener un ambiente comunitario amigable, saludable y valioso, hemos establecido el siguiente código de conducta que todos los usuarios deben seguir:</p>

    <h1>Respeto y Comunicación Positiva</h1>
    <p>Abogamos por una comunicación civilizada y prohibimos estrictamente cualquier forma de ataques personales, insultos o discursos amenazantes. Por favor, respeta a cada miembro y mantiene la armonía y positividad en el espacio en línea.</p>

    <h1>Originalidad y Compartir</h1>
    <p>Alentamos la publicación de contenido original y discusiones técnicas. Comparte tus historias de mascotas, conocimientos sobre cuidados, consejos de entrenamiento o cualquier información beneficiosa para la salud y felicidad de las mascotas.</p>

    <h1>Calidad y Relevancia del Contenido</h1>
    <p>Está prohibido publicar contenido repetitivo, spam, publicaciones fuera de tema o participar en comportamientos repetitivos. Asegúrate de que tus publicaciones sean valiosas para los miembros de la comunidad y relevantes para el tema de mascotas; usa las secciones adecuadas del foro para mantener la claridad organizativa.</p>

    <h1>Normas Legales y Éticas</h1>
    <p>Está absolutamente prohibido publicar contenido ilegal, incluyendo, pero no limitado a, la promoción de actividades ilegales, recursos pirateados, infracción de derechos de autor o distribución de información personal ilegal.</p>

    <h1>Responsabilidad Social</h1>
    <p>Evita todo contenido que contenga pornografía, violencia, abuso o cualquier cosa que pueda causar malestar. Mantén la limpieza y seguridad del entorno en línea.</p>

    <h1>Neutralidad Política</h1>
    <p>Este foro es un santuario para los entusiastas de las mascotas, libre de discusiones políticas para mantener la armonía comunitaria y el enfoque.</p>

    <h1>Normas para el Comportamiento Comercial</h1>
    <p>Está prohibido la publicidad comercial no autorizada y las promociones competitivas. Si necesitas promover productos o servicios relacionados con mascotas, por favor sigue las regulaciones de las áreas específicas de publicidad. Las transacciones personales deben adherirse a principios de integridad, y la característica "respuesta visible solo para el autor" no debe ser abusada, especialmente por usuarios con baja contribución.</p>

    <h1>Protección de la Privacidad</h1>
    <p>Respeta la privacidad de los demás; no divulgues la información personal de nadie sin permiso, incluyendo información de contacto, direcciones, etc.</p>

    <h1>Respeto por los Derechos de Autor</h1>
    <p>Enfatiza la conciencia sobre los derechos de autor; al re-publicar contenido, siempre atribuye al autor original y la fuente, y cumple con la declaración de derechos de autor de la obra original.</p>

    <h1>Manejo de Violaciones</h1>
    <p>El equipo de gestión del foro se reserva el derecho final de adjudicar violaciones, incluyendo, pero no limitado a, ediciones, advertencias, restricciones de acceso e incluso prohibiciones de cuenta.</p>

    <h1>Recompensas por Denuncias y Penalizaciones por Abuso</h1>
    <p>Animamos a los usuarios a reportar violaciones; los informes verificados resultarán en recompensas del foro para el denunciante. Al mismo tiempo, el abuso del mecanismo de denuncia será penalizado adecuadamente.</p>

    <h1>Interacción de Usuarios</h1>
    <p>Participa activamente y comprométete constructivamente para crear un ambiente amigable de ayuda mutua, aprendizaje e intercambio.</p>

    <p>Esperamos que cada miembro de PetJoy se convierta en parte de esta cálida familia, trabajando juntos para mejorar el bienestar de las mascotas. ¡Unamos manos para crear un paraíso para mascotas lleno de amor y conocimiento!</p>

    <p style='text-align: right'>Equipo de Desarrollo de PetJoy</p>
    <p style='text-align: right'>8 de julio de 2024</p>
  </el-container>

  <!--法语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'fr'">
    <p>Bienvenue chez PetJoy, une plateforme conçue pour les passionnés d'animaux de compagnie afin d'échanger des informations et partager des ressources. Afin de maintenir un environnement communautaire amical, sain et précieux, nous avons établi le code de conduite suivant que tous les utilisateurs doivent respecter :</p>

    <h1>Respect et Communication Positive</h1>
    <p>Nous prônons une communication civile et interdisons strictement toute forme d'attaques personnelles, d'insultes ou de discours menaçants. Veuillez respecter chaque membre et maintenir l'harmonie et la positivité dans l'espace en ligne.</p>

    <h1>Originalité et Partage</h1>
    <p>Nous encourageons la publication de contenu original et les discussions techniques. Partagez vos histoires d'animaux, vos connaissances sur les soins, vos astuces de dressage ou toute information bénéfique pour la santé et le bonheur des animaux.</p>

    <h1>Qualité et Pertinence du Contenu</h1>
    <p>Il est interdit de publier du contenu répétitif, du spam, des posts hors-sujet, ou de s'engager dans un comportement répétitif. Assurez-vous que vos publications sont précieuses pour les membres de la communauté et pertinentes pour le thème des animaux ; utilisez les sections appropriées du forum pour maintenir une clarté organisationnelle.</p>

    <h1>Normes Légales et Éthiques</h1>
    <p>La publication de contenu illégal est absolument interdite, y compris mais sans se limiter à la promotion d'activités illégales, de ressources piratées, de violation de droits d'auteur ou de distribution d'informations personnelles illégales.</p>

    <h1>Responsabilité Sociale</h1>
    <p>Évitez tout contenu contenant de la pornographie, de la violence, des abus ou tout ce qui pourrait causer du malaise. Maintenez la propreté et la sécurité de l'environnement en ligne.</p>

    <h1>Neutralité Politique</h1>
    <p>Ce forum est un sanctuaire pour les passionnés d'animaux, libre de discussions politiques pour maintenir l'harmonie de la communauté et rester concentré.</p>

    <h1>Normes pour le Comportement Commercial</h1>
    <p>La publicité commerciale non autorisée et les promotions concurrentielles sont interdites. Si vous devez promouvoir des produits ou services liés aux animaux, veuillez suivre les règlements des zones publicitaires spécifiques. Les transactions personnelles doivent adhérer aux principes d'intégrité, et la fonction "réponse visible uniquement par l'auteur" ne doit pas être abusée, notamment par les utilisateurs à faible contribution.</p>

    <h1>Protection de la Vie Privée</h1>
    <p>Respectez la vie privée des autres ; ne divulguez pas les informations personnelles de quelqu'un sans autorisation, y compris les coordonnées, adresses, etc.</p>

    <h1>Respect du Droit d'Auteur</h1>
    <p>Accentuez la sensibilisation au droit d'auteur ; lors de la republication de contenu, créditez toujours l'auteur original et la source, et conformez-vous à la déclaration de droit d'auteur de l'œuvre originale.</p>

    <h1>Gestion des Violations</h1>
    <p>L'équipe de gestion du forum se réserve le droit final de juger les violations, y compris mais sans s'y limiter, les modifications, les avertissements, les restrictions d'accès et même les interdictions de compte.</p>

    <h1>Récompenses pour les Rapports et Pénalités pour Abus</h1>
    <p>Nous encourageons les utilisateurs à signaler les violations ; les rapports vérifiés entraîneront des récompenses du forum pour le rapporteur. En même temps, l'abus du mécanisme de signalement sera sanctionné de manière appropriée.</p>

    <h1>Interaction des Utilisateurs</h1>
    <p>Participez activement et engagez-vous de manière constructive pour créer un environnement d'apprentissage et d'échange amical et d'entraide.</p>

    <p>Nous attendons avec impatience que chaque membre de PetJoy devienne une partie de cette famille chaleureuse, travaillant ensemble pour améliorer le bien-être des animaux. Unissons nos efforts pour créer un paradis pour animaux rempli d'amour et de connaissance !</p>

    <p style='text-align: right'>Équipe de Développement PetJoy</p>
    <p style='text-align: right'>8 juillet 2024</p>
  </el-container>

  <!--意大利语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'it'">
    <p>Benvenuti su PetJoy, una piattaforma progettata per gli appassionati di animali domestici per scambiare informazioni e condividere risorse. Per mantenere un ambiente comunitario amichevole, salutare e prezioso, abbiamo stabilito il seguente codice di condotta che tutti gli utenti devono rispettare:</p>

    <h1>Rispetto e Comunicazione Positiva</h1>
    <p>Promuoviamo una comunicazione civile e proibiamo rigorosamente qualsiasi forma di attacchi personali, insulti o discorsi minacciosi. Per favore, rispetta ogni membro e mantieni armonia e positività nello spazio online.</p>

    <h1>Originalità e Condivisione</h1>
    <p>Incoraggiamo la pubblicazione di contenuti originali e discussioni tecniche. Condividi le tue storie di animali domestici, conoscenze sulla cura, consigli di addestramento o qualsiasi informazione utile alla salute e felicità degli animali.</p>

    <h1>Qualità e Rilevanza del Contenuto</h1>
    <p>È vietato pubblicare contenuti ripetitivi, spam, post fuori tema o impegnarsi in comportamenti ripetitivi. Assicurati che i tuoi post siano di valore per i membri della comunità e pertinenti al tema degli animali domestici; utilizza le sezioni appropriate del forum per mantenere la chiarezza organizzativa.</p>

    <h1>Standard Legali ed Etici</h1>
    <p>È assolutamente vietato pubblicare contenuti illegali, inclusi ma non limitati alla promozione di attività illegali, risorse piratate, violazione del diritto d'autore o distribuzione di informazioni personali illegali.</p>

    <h1>Responsabilità Sociale</h1>
    <p>Evita tutti i contenuti che contengono pornografia, violenza, abuso o qualsiasi cosa possa causare disagio. Mantieni la pulizia e la sicurezza dell'ambiente online.</p>

    <h1>Neutralità Politica</h1>
    <p>Questo forum è un rifugio per gli appassionati di animali domestici, libero da discussioni politiche per mantenere l'armonia della comunità e la concentrazione.</p>

    <h1>Standard per il Comportamento Commerciale</h1>
    <p>La pubblicità commerciale non autorizzata e le promozioni competitive sono proibite. Se devi promuovere prodotti o servizi relativi agli animali domestici, segui le regolamentazioni delle aree pubblicitarie specifiche. Le transazioni personali devono attenersi ai principi di integrità, e la funzione "risposta visibile solo all'autore" non deve essere abusata, specialmente dagli utenti a basso contributo.</p>

    <h1>Protezione della Privacy</h1>
    <p>Rispetta la privacy altrui; non divulgare informazioni personali di nessuno senza permesso, inclusi contatti, indirizzi, ecc.</p>

    <h1>Rispetto del Diritto d'Autore</h1>
    <p>Enfatizza la consapevolezza sul diritto d'autore; quando ripubblichi contenuti, accredita sempre l'autore originale e la fonte, e rispetta la dichiarazione del diritto d'autore dell'opera originale.</p>

    <h1>Gestione delle Violazioni</h1>
    <p>Il team di gestione del forum si riserva il diritto finale di giudicare le violazioni, inclusi ma non limitati a modifiche, avvertimenti, restrizioni di accesso e anche divieti di account.</p>

    <h1>Ricompense per le Segnalazioni e Penalità per Abusi</h1>
    <p>Incitiamo gli utenti a segnalare le violazioni; le segnalazioni verificate risulteranno in ricompense del forum per il denunciante. Allo stesso tempo, l'abuso del meccanismo di segnalazione sarà penalizzato in modo appropriato.</p>

    <h1>Interazione degli Utenti</h1>
    <p>Partecipa attivamente e impegnati in modo costruttivo per creare un ambiente amichevole di apprendimento e scambio reciproco.</p>

    <p>Speriamo che ogni membro di PetJoy diventi parte di questa famiglia calorosa, lavorando insieme per migliorare il benessere degli animali. Uniamoci per creare un paradiso per animali domestici pieno di amore e conoscenza!</p>

    <p style='text-align: right'>Team di Sviluppo PetJoy</p>
    <p style='text-align: right'>8 luglio 2024</p>
  </el-container>

  <!--日语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ja'">
    <p>PetJoy へようこそ。これはペット愛好家が情報を交換し、リソースを共有するために設計されたプラットフォームです。フレンドリーで健康的で価値あるコミュニティ環境を維持するために、全ユーザーが遵守すべき以下の行動規範を設けています：</p>

    <h1>尊重とポジティブなコミュニケーション</h1>
    <p>私たちは礼儀正しいコミュニケーションを推奨し、個人攻撃、侮辱、脅迫的な言動を厳しく禁じています。各メンバーを尊重し、オンライン空間での調和とポジティブな雰囲気を保ってください。</p>

    <h1>オリジナリティと共有</h1>
    <p>オリジナルコンテンツの投稿や技術的な議論を奨励します。ペットの話、ケアの知識、トレーニングのヒント、またはペットの健康と幸福に役立つ情報を共有してください。</p>

    <h1>コンテンツの質と関連性</h1>
    <p>繰り返しのコンテンツ投稿、スパム、話題から外れた投稿、または繰り返しの行動に従事することは禁止されています。投稿がコミュニティメンバーにとって価値があり、ペットのテーマに関連していることを確認してください。組織的な明瞭性を保つために適切なフォーラムセクションを使用してください。</p>

    <h1>法的および倫理的基準</h1>
    <p>違法なコンテンツの投稿は絶対に禁止されています。これには、違法行為の推進、海賊版リソースの提供、著作権侵害、または違法な個人情報の配布などが含まれますが、これに限定されません。</p>

    <h1>社会的責任</h1>
    <p>ポルノ、暴力、虐待、または不快感を引き起こす可能性のあるすべてのコンテンツを避けてください。オンライン環境の清潔さと安全を保持してください。</p>

    <h1>政治的中立</h1>
    <p>このフォーラムはペット愛好家のための避難所であり、コミュニティの調和と集中を保つために政治的議論から自由です。</p>

    <h1>商業行動の基準</h1>
    <p>許可されていない商業広告や競争的なプロモーションは禁止されています。ペット関連の製品やサービスを宣伝する必要がある場合は、特定の広告エリアの規制に従ってください。個人取引は誠実さの原則に従うべきであり、「作者のみに回答が表示される」という機能の濫用は避けるべきです。特に投稿が少ないユーザーによる濫用を防ぎます。</p>

    <h1>プライバシー保護</h1>
    <p>他人のプライバシーを尊重し、許可なく誰かの個人情報（連絡先情報、住所など）を公開しないでください。</p>

    <h1>著作権の尊重</h1>
    <p>著作権意識を重視し、コンテンツを再投稿する場合は常に元の著者と出典をクレジットし、オリジナル作品の著作権声明に従ってください。</p>

    <h1>違反処理</h1>
    <p>フォーラム管理チームは、編集、警告、アクセス制限、さらにはアカウントの禁止を含むがこれに限定されない違反の最終的な裁定権を保持します。</p>

    <h1>違反報告の報酬と乱用への罰則</h1>
    <p>ユーザーによる違反の報告を奨励しています。検証された報告は報告者にフォーラムの報酬をもたらします。同時に、報告メカニズムの乱用は適切に罰せられます。</p>

    <h1>ユーザー間の交流</h1>
    <p>積極的に参加し、建設的な関与を通じて、友好的で相互に助け合いながら学び、交流する環境を創造しましょう。</p>

    <p>PetJoy の暖かい家族の一員となり、一緒にペットの福祉を向上させることを楽しみにしています。愛と知識に満ちたペットの楽園を共に創造しましょう！</p>

    <p style='text-align: right'>PetJoy 開発チーム</p>
    <p style='text-align: right'>2024 年 7 月 8 日</p>
  </el-container>

  <!--韩语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ko'">
    <p>PetJoy 에 오신 것을 환영합니다. 이 플랫폼은 반려동물 애호가들이 정보를 교환하고 자원을 공유할 수 있도록 설계되었습니다. 친근하고 건강하며 가치 있는 커뮤니티 환경을 유지하기 위해 모든 사용자가 준수해야 할 다음과 같은 행동 규범을 마련했습니다:</p>

    <h1>존중과 긍정적인 소통</h1>
    <p>우리는 예의 바른 소통을 지지하며 개인 공격, 모욕 또는 위협적인 언어 사용을 엄격히 금지합니다. 각 구성원을 존중하고 온라인 공간에서의 조화와 긍정성을 유지해 주세요.</p>

    <h1>창의성과 공유</h1>
    <p>오리지널 콘텐츠 게시와 기술적 토론을 장려합니다. 반려동물 이야기, 돌보기 지식, 훈련 팁 또는 반려동물의 건강과 행복에 도움이 되는 정보를 공유해 주세요.</p>

    <h1>콘텐츠 품질과 관련성</h1>
    <p>반복적인 콘텐츠 게시, 스팸, 주제에서 벗어난 게시물 게시 또는 반복적인 행동에 참여하는 것은 금지됩니다. 게시물이 커뮤니티 구성원에게 가치가 있고 반려동물 주제와 관련이 있는지 확인하십시오; 조직적 명료성을 유지하기 위해 적절한 포럼 섹션을 사용하십시오.</p>

    <h1>법적 및 윤리적 기준</h1>
    <p>불법 콘텐츠의 게시는 절대 금지되어 있으며, 이에는 불법 활동의 촉진, 해적판 자원의 제공, 저작권 침해, 불법 개인 정보의 배포 등이 포함되지만 이에 국한되지 않습니다.</p>

    <h1>사회적 책임</h1>
    <p>포르노, 폭력, 학대 또는 불편을 유발할 수 있는 모든 콘텐츠를 피하십시오. 온라인 환경의 청결과 안전을 유지하십시오.</p>

    <h1>정치적 중립성</h1>
    <p>이 포럼은 반려동물 애호가들을 위한 피난처로서, 커뮤니티의 조화와 집중을 유지하기 위해 정치적 논의로부터 자유롭습니다.</p>

    <h1>상업적 행위 기준</h1>
    <p>승인되지 않은 상업 광고와 경쟁적 프로모션은 금지됩니다. 반려동물 관련 제품이나 서비스를 홍보해야 하는 경우 특정 광고 영역의 규정을 따르십시오. 개인 거래는 정직의 원칙을 준수해야 하며, '작성자만 볼 수 있는 답변' 기능을 남용하지 말아야 합니다. 특히 기여도가 낮은 사용자에 의한 남용을 방지하십시오.</p>

    <h1>개인 정보 보호</h1>
    <p>타인의 개인 정보를 존중하십시오; 허가 없이 누구의 개인 정보도 공개하지 마십시오. 여기에는 연락처 정보, 주소 등이 포함됩니다.</p>

    <h1>저작권 존중</h1>
    <p>저작권에 대한 인식을 강조하십시오; 콘텐츠를 재게시할 때는 항상 원작자와 출처를 명시하고 원작의 저작권 선언을 준수하십시오.</p>

    <h1>위반 처리</h1>
    <p>포럼 관리 팀은 수정, 경고, 접근 제한 및 계정 금지를 포함하되 이에 국한되지 않는 위반에 대한 최종적인 결정권을 보유합니다.</p>

    <h1>신고 보상 및 남용에 대한 처벌</h1>
    <p>사용자가 위반을 신고하도록 장려합니다; 검증된 신고는 신고자에게 포럼 보상을 제공합니다. 동시에, 신고 메커니즘의 남용은 적절히 처벌될 것입니다.</p>

    <h1>사용자 상호작용</h1>
    <p>적극적으로 참여하고 건설적으로 관여하여 친근하고 상호 도움이 되는 학습 및 교류 환경을 만드십시오.</p>

    <p>PetJoy 의 따뜻한 가족의 일원이 되어 모두 함께 반려동물의 복지를 향상시키기를 기대합니다. 사랑과 지식으로 가득 찬 반려동물의 천국을 함께 만들어 갑시다!</p>

    <p style='text-align: right'>PetJoy 개발팀</p>
    <p style='text-align: right'>2024 년 7 월 8 일</p>
  </el-container>

  <!--葡萄牙语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'pt'">
    <p>Bem-vindo ao PetJoy, uma plataforma projetada para entusiastas de animais de estimação trocarem informações e compartilharem recursos. Para manter um ambiente comunitário amigável, saudável e valioso, estabelecemos o seguinte código de conduta que todos os usuários devem seguir:</p>

    <h1>Respeito e Comunicação Positiva</h1>
    <p>Advogamos pela comunicação civilizada e proibimos estritamente qualquer forma de ataques pessoais, insultos ou discursos ameaçadores. Respeite cada membro e mantenha a harmonia e a positividade no espaço online.</p>

    <h1>Originalidade e Compartilhamento</h1>
    <p>Encorajamos a postagem de conteúdo original e discussões técnicas. Compartilhe suas histórias de animais de estimação, conhecimentos sobre cuidados, dicas de treinamento ou qualquer informação benéfica para a saúde e felicidade dos pets.</p>

    <h1>Qualidade e Relevância do Conteúdo</h1>
    <p>Postar conteúdo repetitivo, spam, posts fora do tópico ou envolver-se em comportamentos repetitivos é proibido. Garanta que suas postagens sejam valiosas para os membros da comunidade e relevantes para o tema de animais de estimação; use as seções apropriadas do fórum para manter a clareza organizacional.</p>

    <h1>Padrões Legais e Éticos</h1>
    <p>A postagem de conteúdo ilegal é absolutamente proibida, incluindo, mas não se limitando a, promoção de atividades ilegais, recursos piratas, violação de direitos autorais ou distribuição de informações pessoais ilegais.</p>

    <h1>Responsabilidade Social</h1>
    <p>Evite todo conteúdo que contenha pornografia, violência, abuso ou qualquer coisa que possa causar desconforto. Mantenha a limpeza e segurança do ambiente online.</p>

    <h1>Neutralidade Política</h1>
    <p>Este fórum é um santuário para entusiastas de animais de estimação, livre de discussões políticas para manter a harmonia da comunidade e o foco.</p>

    <h1>Padrões para Comportamento Comercial</h1>
    <p>Publicidade comercial não autorizada e promoções competitivas são proibidas. Se você precisa promover produtos ou serviços relacionados a animais de estimação, siga as regulamentações das áreas de publicidade específicas. Transações pessoais devem aderir aos princípios de integridade, e a função "resposta visível apenas para o autor" não deve ser abusada, especialmente por usuários de baixa contribuição.</p>

    <h1>Proteção de Privacidade</h1>
    <p>Respeite a privacidade dos outros; não divulgue informações pessoais de alguém sem permissão, incluindo informações de contato, endereços, etc.</p>

    <h1>Respeito aos Direitos Autorais</h1>
    <p>Enfatize a consciência sobre direitos autorais; ao republicar conteúdo, sempre credite o autor original e a fonte, e cumpra com a declaração de direitos autorais da obra original.</p>

    <h1>Tratamento de Violações</h1>
    <p>A equipe de gestão do fórum reserva o direito final de julgar violações, incluindo, mas não limitado a, edições, advertências, restrições de acesso e até banimento de contas.</p>

    <h1>Recompensas por Denúncias e Penalidades por Abuso</h1>
    <p>Encorajamos os usuários a denunciar violações; denúncias verificadas resultarão em recompensas do fórum para o denunciante. Ao mesmo tempo, o abuso do mecanismo de denúncia será devidamente penalizado.</p>

    <h1>Interação entre Usuários</h1>
    <p>Participe ativamente e envolva-se de forma construtiva para criar um ambiente amigável de aprendizado e troca mútua.</p>

    <p>Estamos ansiosos para que cada membro do PetJoy se torne parte desta família calorosa, trabalhando juntos para melhorar o bem-estar dos animais de estimação. Vamos unir forças para criar um paraíso para animais de estimação cheio de amor e conhecimento!</p>

    <p style='text-align: right'>Equipe de Desenvolvimento PetJoy</p>
    <p style='text-align: right'>8 de julho de 2024</p>
  </el-container>

  <!--俄语版本-->
  <el-container direction='vertical' v-else-if="$i18n.locale == 'ru'">
    <p>Добро пожаловать в PetJoy, платформу, созданную для любителей домашних животных, чтобы обмениваться информацией и делиться ресурсами. Для поддержания дружелюбной, здоровой и ценной среды в сообществе мы установили следующий кодекс поведения, которого должны придерживаться все пользователи:</p>

    <h1>Уважение и позитивное общение</h1>
    <p>Мы выступаем за цивилизованное общение и строго запрещаем любые формы личных нападок, оскорблений или угрожающих высказываний. Пожалуйста, уважайте каждого участника и поддерживайте гармонию и позитив в онлайн-пространстве.</p>

    <h1>Оригинальность и обмен</h1>
    <p>Мы поощряем публикацию оригинального контента и технические обсуждения. Делитесь своими историями о домашних животных, знаниями о уходе, советами по обучению или любой информацией, способствующей здоровью и счастью питомцев.</p>

    <h1>Качество и актуальность контента</h1>
    <p>Запрещено публиковать повторяющийся контент, спам, сообщения не по теме или участвовать в повторяющемся поведении. Убедитесь, что ваши сообщения ценны для членов сообщества и соответствуют теме домашних животных; используйте соответствующие разделы форума для поддержания организационной ясности.</p>

    <h1>Юридические и этические стандарты</h1>
    <p>Публикация незаконного контента абсолютно запрещена, включая, но не ограничиваясь, продвижением незаконной деятельности, пиратскими ресурсами, нарушением авторских прав или распространением незаконной личной информации.</p>

    <h1>Социальная ответственность</h1>
    <p>Избегайте любого контента, содержащего порнографию, насилие, злоупотребление или что-либо, что может вызвать дискомфорт. Поддерживайте чистоту и безопасность онлайн-среды.</p>

    <h1>Политическая нейтральность</h1>
    <p>Этот форум - убежище для любителей домашних животных, свободное от политических дискуссий для поддержания гармонии сообщества и сосредоточенности.</p>

    <h1>Стандарты коммерческого поведения</h1>
    <p>Несанкционированная коммерческая реклама и конкурентные продвижения запрещены. Если вам необходимо продвигать продукты или услуги, связанные с домашними животными, пожалуйста, следуйте правилам специфических рекламных зон. Личные сделки должны соответствовать принципам добросовестности, и функция «ответ виден только автору» не должна злоупотребляться, особенно пользователями с низким вкладом.</p>

    <h1>Защита конфиденциальности</h1>
    <p>Уважайте частную жизнь других; не разглашайте чью-либо личную информацию без разрешения, включая контактные данные, адреса и т. д.</p>

    <h1>Уважение к авторским правам</h1>
    <p>Подчеркивайте осведомленность о авторских правах; при перепосте контента всегда указывайте оригинального автора и источник, и соблюдайте декларацию авторских прав оригинального произведения.</p>

    <h1>Обращение с нарушениями</h1>
    <p>Команда управления форумом оставляет за собой окончательное право судить о нарушениях, включая, но не ограничиваясь, правками, предупреждениями, ограничениями доступа и даже блокировкой аккаунтов.</p>

    <h1>Награды за сообщения о нарушениях и штрафы за злоупотребления</h1>
    <p>Мы поощряем пользователей сообщать о нарушениях; проверенные сообщения приведут к вознаграждениям на форуме для сообщившего. В то же время злоупотребление механизмом сообщений будет надлежащим образом наказано.</p>

    <h1>Взаимодействие пользователей</h1>
    <p>Активно участвуйте и конструктивно взаимодействуйте, чтобы создать дружественную среду взаимопомощи, обучения и обмена.</p>

    <p>Мы с нетерпением ждем, когда каждый член PetJoy станет частью нашей теплой семьи, работая вместе для улучшения благосостояния домашних животных. Давайте вместе создадим рай для питомцев, наполненный любовью и знаниями!</p>

    <p style='text-align: right'>Команда разработчиков PetJoy</p>
    <p style='text-align: right'>8 июля 2024 года</p>
  </el-container>

  <!--汉语（默认语言）版本-->
  <el-container direction='vertical' v-else>
    <p>欢迎来到宠悦（PetJoy），一个专为宠物爱好者打造的信息交流与资源共享平台。为了维护一个友好、健康、有价值的社区环境，我们制定了以下行为准则，请所有用户共同遵守：</p>

    <h1>尊重与正面交流</h1>
    <p>我们倡导文明交流，严禁任何形式的人身攻击、侮辱或威胁性言论。请尊重每位成员，保持网络空间的和谐与正向。</p>

    <h1>原创与分享</h1>
    <p>鼓励原创内容的发布与技术性讨论。分享你的宠物故事、护理知识、训练技巧或任何有益于宠物健康与幸福的信息。</p>

    <h1>内容质量与相关性</h1>
    <p>禁止发布重复内容、垃圾信息、无关主题的帖子或进行复读行为。确保你的帖子对社区成员有价值且与宠物主题相关；版块分类明确，请在相应的版块发布内容，以保持论坛的组织性。</p>

    <h1>法律与道德规范</h1>
    <p>绝不容许任何违法内容的发布，包括但不限于非法活动宣传、盗版资源、侵犯版权或传播非法个人信息。</p>

    <h1>社会责任</h1>
    <p>杜绝一切含有色情、暴力、辱骂或任何可能引起不适的内容。维护网络环境的清洁与安全。</p>

    <h1>政治中立</h1>
    <p>本论坛为宠物爱好者的净土，避免一切政治话题的讨论，以维护社区的和谐与专注。</p>

    <h1>商业行为规范</h1>
    <p>禁止未经许可的商业广告与竞争性推广。若需宣传宠物相关产品或服务，请遵循特定广告区域的规定。个人交易应遵循诚信原则，不得滥用“回帖仅作者可见”功能，尤其是对于低贡献度用户。</p>

    <h1>个人隐私保护</h1>
    <p>尊重他人隐私，未经允许不得公开他人的个人信息，包括联系方式、地址等。</p>

    <h1>版权尊重</h1>
    <p>强调版权意识，转载内容时务必注明原作者与来源，遵守原作的版权声明。</p>

    <h1>违规处理</h1>
    <p>论坛管理团队保留对违规行为的最终裁决权，包括但不限于编辑、警告、限制访问乃至账号封禁等措施。</p>

    <h1>举报奖励与滥用惩罚</h1>
    <p>鼓励用户对违规内容进行举报，核实后将对首报者给予论坛内奖励。同时，滥用举报机制将受到相应处罚。</p>

    <h1>用户互动</h1>
    <p>积极参与，建设性地交流，共同营造一个友好、互助的学习与交流环境。</p>

    <p>我们期待每一位宠悦（PetJoy）的成员都能成为这个温馨大家庭的一份子，共同为提升宠物福祉而努力。让我们携手创造一个充满爱与知识的宠物乐园！</p>

    <p style='text-align: right'>宠悦 | PetJoy 项目开发组</p>
    <p style='text-align: right'>2024 年 7 月 8 日</p>
  </el-container>
</template>

<style scoped>
@import '../styles/FooterNavbarTextCSS.css';
</style>
