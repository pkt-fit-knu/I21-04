﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Console_iris1.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Console_iris1.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на 5.1,3.5,1.4,0.2,Iris-setosa
        ///4.9,3.0,1.4,0.2,Iris-setosa
        ///4.7,3.2,1.3,0.2,Iris-setosa
        ///4.6,3.1,1.5,0.2,Iris-setosa
        ///5.0,3.6,1.4,0.2,Iris-setosa
        ///5.4,3.9,1.7,0.4,Iris-setosa
        ///4.6,3.4,1.4,0.3,Iris-setosa
        ///5.0,3.4,1.5,0.2,Iris-setosa
        ///4.4,2.9,1.4,0.2,Iris-setosa
        ///4.9,3.1,1.5,0.1,Iris-setosa
        ///5.4,3.7,1.5,0.2,Iris-setosa
        ///4.8,3.4,1.6,0.2,Iris-setosa
        ///4.8,3.0,1.4,0.1,Iris-setosa
        ///4.3,3.0,1.1,0.1,Iris-setosa
        ///5.8,4.0,1.2,0.2,Iris-setosa
        ///5.7,4.4,1.5,0.4,Iris-setosa
        ///5.4,3.9,1.3,0.4,Iris-setosa
        ///5.1,3.5,1.4,0.3,Iri [остаток строки не уместился]&quot;;.
        /// </summary>
        public static string IrisData {
            get {
                return ResourceManager.GetString("IrisData", resourceCulture);
            }
        }
    }
}