import xml.etree.ElementTree as ET
import os, sys, re, json

svg_file = sys.argv[1]
trixels_width = int(sys.argv[2])
trixels_height = int(sys.argv[3])
svg_root = ET.parse(svg_file).getroot()

#print (str(trixels_width) + " " + str(trixels_height))

trixel_layer = svg_root.findall(".//*[@id='Trixel Layer']")[0]

trixels_grid = [[0 for x in range(trixels_width)] for y in range(trixels_height)] 
x = 0
y = 0
csv_string = ''
for group in trixel_layer:
    #print (str(x) + " " + str(y))
    #if x == trixels_width:
    #    y += 1
    #    x = 0
    style_attr = group[0].attrib["style"]
    regex = r"(#(......))"
    m = re.search(regex, style_attr)
    hexel_color = int(m.group(2), 16)
    csv_string += str(hexel_color) + ","
    #x += 1

print(csv_string[:-1])