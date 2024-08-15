# cs2-killfeed-icons
**a plugin to customize the killfeed icons**

<br>

<img src="https://github.com/user-attachments/assets/db91d07e-2550-4bf2-b5c2-e4a0f4002873" width="150">

<br>

<details>
<summary>list of cs2 icons & weapon names</summary>
ak47<br>
ammobox<br>
ammobox_threepack<br>
armor<br>
armor_helmet<br>
assaultsuit<br>
assaultsuit_helmet_only<br>
aug<br>
awp<br>
axe<br>
bayonet<br>
bizon<br>
breachcharge<br>
breachcharge_projectile<br>
bumpmine<br>
c4<br>
clothing_hands<br>
controldrone<br>
customplayer<br>
cz75a<br>
deagle<br>
decoy<br>
defuser<br>
disconnect<br>
diversion<br>
dronegun<br>
elite<br>
famas<br>
firebomb<br>
fists<br>
fiveseven<br>
flair0<br>
flashbang<br>
flashbang_assist<br>
frag_grenade<br>
g3sg1<br>
galilar<br>
glock<br>
grenadepack<br>
grenadepack2<br>
hammer<br>
healthshot<br>
heavy_armor<br>
hegrenade<br>
helmet<br>
hkp2000<br>
incgrenade<br>
inferno<br>
kevlar<br>
knife<br>
knife_bowie<br>
knife_butterfly<br>
knife_canis<br>
knife_cord<br>
knife_css<br>
knife_falchion<br>
knife_flip<br>
knife_gut<br>
knife_gypsy_jackknife<br>
knife_karambit<br>
knife_kukri<br>
knife_m9_bayonet<br>
knife_outdoor<br>
knife_push<br>
knife_skeleton<br>
knife_stiletto<br>
knife_survival_bowie<br>
knife_t<br>
knife_tactical<br>
knife_twinblade<br>
knife_ursus<br>
knife_widowmaker<br>
knifegg<br>
m4a1<br>
m4a1_silencer<br>
m4a1_silencer_off<br>
m249<br>
mac10<br>
mag7<br>
melee<br>
molotov<br>
mp5sd<br>
mp7<br>
mp9<br>
negev<br>
nova<br>
p90<br>
p250<br>
p2000<br>
planted_c4<br>
planted_c4_survival<br>
prop_exploding_barrel<br>
radarjammer<br>
revolver<br>
sawedoff<br>
scar20<br>
sg556<br>
shield<br>
smokegrenade<br>
snowball<br>
spanner<br>
spray0<br>
ssg08<br>
stomp_damage<br>
tablet<br>
tagrenade<br>
taser<br>
tec9<br>
tripwirefire<br>
tripwirefire_projectile<br>
ump45<br>
usp_silencer<br>
usp_silencer_off<br>
xm1014<br>
zone_repulsor<br>
</details>

can be found in `game/csgo/panorama/images/icons/equipment` with [Source2 Viewer](https://valveresourceformat.github.io/) <br>


<br>

## information:

### requirements
- [MetaMod](https://cs2.poggu.me/metamod/installation)
- [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp)

<br>

> [!WARNING]
> add `"include" "panorama/images/icons/equipment"` at the bottom of gameinfo.gi before uploading addon
>
> also don't forget to remove it when you're done or you wont be able to join servers

to make your own icon you have to upload a .svg file to that path in your addon <br>
`"Icon": "YOUR-ICON"` = content/your-addon/panorama/images/icons/equipment/YOUR-ICON.svg

## example config
```json
{
  "Icons": {
    "knife": {
      "Icon": "knife"
    },
    "awp": {
      "Icon": "awp",
      "Permission": "@css/reservation",
      "Team": "T"
    }
  }
}
```

<br> <a href="https://ko-fi.com/exkludera" target="blank"><img src="https://cdn.ko-fi.com/cdn/kofi5.png" height="48px" alt="Buy Me a Coffee at ko-fi.com"></a>
