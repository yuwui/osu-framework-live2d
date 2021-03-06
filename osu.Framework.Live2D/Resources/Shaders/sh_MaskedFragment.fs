#include "sh_Utils.h"

varying vec2 v_texCoord;
varying vec4 v_clipPos;
uniform sampler2D s_texture0;
uniform sampler2D s_texture1;
uniform vec4 u_channelFlag;
uniform vec4 u_baseColor;

void main() {
    vec4 col_forMask = toSRGB(texture2D(s_texture0, v_texCoord) * u_baseColor);
    col_forMask.rgb = col_forMask.rgb * col_forMask.a;
    
    vec4 clipMask = (1.0 - texture2D(s_texture1, v_clipPos.xy / v_clipPos.w)) * u_channelFlag;
    float maskVal = clipMask.r + clipMask.g + clipMask.b + clipMask.a;

    col_forMask = col_forMask * maskVal;
    gl_FragColor = col_forMask;
}