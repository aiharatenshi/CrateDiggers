<map version="0.9.0">
<!-- To view this file, download free mind mapping software FreeMind from http://freemind.sourceforge.net -->
<node CREATED="1381252634967" ID="ID_1887644422" MODIFIED="1381253861953">
<richcontent TYPE="NODE"><html>
  <head>
    
  </head>
  <body>
    <p style="text-align: center">
      CRATEDIGGERS
    </p>
    <p style="text-align: center">
      <font size="2">Class map </font>
    </p>
    <p>
      
    </p>
    <p>
      <font size="2"><b>BOLD</b>: categories </font>
    </p>
    <p>
      <font size="2">red: abstract</font>
    </p>
  </body>
</html></richcontent>
<edge STYLE="linear" WIDTH="4"/>
<font BOLD="true" NAME="MS PMincho" SIZE="19"/>
<node CREATED="1381254848754" ID="ID_641273766" MODIFIED="1381254901942" POSITION="right" TEXT="INTERACTIVE_OBJECTS">
<font BOLD="true" NAME="MS PMincho" SIZE="12"/>
<node COLOR="#ff3333" CREATED="1381252719768" ID="ID_1934922469" MODIFIED="1381421743852" TEXT="InteractiveObjectBase">
<font NAME="MS PMincho" SIZE="12"/>
<node COLOR="#ff3333" CREATED="1381252779269" ID="ID_862803469" MODIFIED="1381253773248" TEXT="NonControllableBase"/>
<node COLOR="#ff3333" CREATED="1381253404449" ID="ID_810451722" MODIFIED="1381253771010" TEXT="ControllableCharacterBase"/>
<node CREATED="1381421746146" ID="ID_1515690504" MODIFIED="1381421751761" TEXT="CompetitorBase">
<node CREATED="1381421754188" ID="ID_942618862" MODIFIED="1381421758259" TEXT="ControllableCompetitor">
<node CREATED="1381252744787" ID="ID_1900495027" MODIFIED="1381253782360" TEXT="CompetitivePlayerDefault">
<node CREATED="1381252752659" ID="ID_1828781760" MODIFIED="1381253455962" TEXT="CompetitivePlayerSubType"/>
</node>
</node>
<node COLOR="#ff3333" CREATED="1381253948905" ID="ID_1586340015" MODIFIED="1381253981318" TEXT="TurretBase">
<node CREATED="1381253970394" ID="ID_335928945" MODIFIED="1381253976940" TEXT="PlasmaTurret"/>
</node>
</node>
</node>
</node>
<node CREATED="1381252876232" ID="ID_1002562805" MODIFIED="1381253546661" POSITION="left" TEXT="HELPERS">
<font BOLD="true" NAME="MS PMincho" SIZE="12"/>
<node CREATED="1381253317765" ID="ID_1050239922" MODIFIED="1381253319708" TEXT="Hitbox"/>
<node CREATED="1381254273579" ID="ID_414221088" MODIFIED="1381254275796" TEXT="Respawn"/>
<node CREATED="1381254276956" ID="ID_220317002" MODIFIED="1381254279314" TEXT="WorldArea"/>
<node CREATED="1381254337926" ID="ID_134543933" MODIFIED="1381254340237" TEXT="Constants"/>
<node CREATED="1381254352379" ID="ID_1860371124" MODIFIED="1381254357061" TEXT="TimerScript"/>
<node CREATED="1381254357504" ID="ID_1024503882" MODIFIED="1381254364354" TEXT="PossessionTimer"/>
</node>
<node CREATED="1381252891556" ID="ID_1410607389" MODIFIED="1381253548376" POSITION="left" TEXT="INPUT">
<font BOLD="true" NAME="MS PMincho" SIZE="12"/>
<node CREATED="1381252894456" ID="ID_1273707920" MODIFIED="1381252900688" TEXT="GamepadInputHandler"/>
<node CREATED="1381252902863" ID="ID_916304887" MODIFIED="1381252906133" TEXT="CamepadInfo"/>
<node CREATED="1381252907314" ID="ID_1523515204" MODIFIED="1381252908909" TEXT="Controller"/>
</node>
<node CREATED="1381252921491" ID="ID_1446285076" MODIFIED="1381254308549" POSITION="left" TEXT="MANAGERS">
<font BOLD="true" NAME="MS PMincho" SIZE="12"/>
<node CREATED="1381254309336" ID="ID_1730374196" MODIFIED="1381254315173" TEXT="CompGameManager"/>
<node CREATED="1381254315522" ID="ID_1504586992" MODIFIED="1381254319939" TEXT="FrameWorldManager"/>
<node CREATED="1381254320693" ID="ID_1769226265" MODIFIED="1381254325048" TEXT="TempGameManager"/>
<node CREATED="1381254565768" ID="ID_483328555" MODIFIED="1381254569327" TEXT="RockPaperScissors"/>
</node>
<node CREATED="1381253111771" ID="ID_840982937" MODIFIED="1381253544346" POSITION="right" TEXT="ABILITIES">
<font BOLD="true" NAME="MS PMincho" SIZE="12"/>
<node COLOR="#ff3333" CREATED="1381252794921" ID="ID_1394369725" MODIFIED="1381253724974" TEXT="AbilityBase">
<node COLOR="#ff3333" CREATED="1381252802340" ID="ID_1853350972" MODIFIED="1381253758824" TEXT="ProjectileAbilityBase">
<node CREATED="1381252988482" ID="ID_1358990353" MODIFIED="1381252993738" TEXT="PlasmaGunAbility"/>
</node>
<node COLOR="#ff3333" CREATED="1381252823539" ID="ID_209617000" MODIFIED="1381253761198" TEXT="AuraAbilityBase"/>
<node COLOR="#ff3333" CREATED="1381252978716" ID="ID_284801031" MODIFIED="1381253763498" TEXT="MeleeAbilityBase"/>
<node COLOR="#ff3333" CREATED="1381253025978" ID="ID_122586591" MODIFIED="1381253766163" TEXT="BallAbilityBase">
<node CREATED="1381253035362" ID="ID_101391965" MODIFIED="1381253037565" TEXT="PassBall"/>
<node CREATED="1381253046544" ID="ID_706761883" MODIFIED="1381253048172" TEXT="DropBall"/>
</node>
</node>
<node COLOR="#ff3333" CREATED="1381253165117" ID="ID_1871734783" MODIFIED="1381253731800" TEXT="AbilityInstanceBase">
<node COLOR="#ff3333" CREATED="1381253075689" ID="ID_1028509875" MODIFIED="1381253744044" TEXT="ProjectileBase">
<node CREATED="1381253234435" ID="ID_281011464" MODIFIED="1381253247069" TEXT="KinematicProjectile">
<node CREATED="1381253279597" ID="ID_1682085721" MODIFIED="1381253285358" TEXT="PlasmaBurst"/>
</node>
<node CREATED="1381253247612" ID="ID_910062329" MODIFIED="1381253276467" TEXT="NonkinematicProjectile"/>
</node>
<node COLOR="#ff3333" CREATED="1381253177407" ID="ID_101554221" MODIFIED="1381253746794" TEXT="AuraBase">
<node CREATED="1381253213129" ID="ID_798278631" MODIFIED="1381253222465" TEXT="AttachedAura"/>
<node CREATED="1381253222827" ID="ID_874875239" MODIFIED="1381253226006" TEXT="EnvironmentalAura"/>
</node>
</node>
</node>
<node CREATED="1381254369820" ID="ID_1803588351" MODIFIED="1381254372184" POSITION="right" TEXT="GUI">
<font BOLD="true" NAME="MS PMincho" SIZE="12"/>
<node CREATED="1381254437277" ID="ID_474637739" MODIFIED="1381254440259" TEXT="CameraGUI"/>
<node COLOR="#ff3333" CREATED="1381254475840" ID="ID_1236849113" MODIFIED="1381254495132" TEXT="TextMeshBase">
<node CREATED="1381254461496" ID="ID_1350463644" MODIFIED="1381254464914" TEXT="PlayerRPSChoice"/>
<node CREATED="1381254454375" ID="ID_840102284" MODIFIED="1381254456732" TEXT="NameTextMesh"/>
<node CREATED="1381254445553" ID="ID_1579366258" MODIFIED="1381254448222" TEXT="DialogueBox"/>
<node CREATED="1381254399767" ID="ID_1210162715" MODIFIED="1381254402124" TEXT="AreaName"/>
<node COLOR="#ff3333" CREATED="1381254373970" ID="ID_947522248" MODIFIED="1381254426492" TEXT="ScoreboardBase">
<node CREATED="1381254408152" ID="ID_409056499" MODIFIED="1381254411820" TEXT="BettingScoreboard"/>
<node CREATED="1381254412153" ID="ID_1044428357" MODIFIED="1381254418879" TEXT="PossessionScoreboard"/>
</node>
<node CREATED="1381254420772" ID="ID_434089995" MODIFIED="1381254423083" TEXT="RoundTime"/>
</node>
</node>
<node CREATED="1381254781018" ID="ID_1209661458" MODIFIED="1381254815643" POSITION="right" TEXT="ENVIRONMENT">
<font BOLD="true" NAME="MS PMincho" SIZE="12"/>
</node>
</node>
</map>
