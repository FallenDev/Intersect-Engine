﻿using Intersect.GameObjects;
using Intersect.GameObjects.Switches_and_Variables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Intersect.Server.Database.PlayerData.Players
{
    public class Variable
    {

        public Variable() : this(Guid.Empty) { }

        public Variable(Guid id)
        {
            VariableId = id;
        }

        [JsonIgnore]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; protected set; } = Guid.NewGuid();

        public Guid VariableId { get; protected set; }

        [NotMapped]
        [JsonIgnore]
        public VariableValue Value { get; set; } = new VariableValue();

        [NotMapped]
        [JsonProperty("Value")]
        public dynamic ValueData => Value.Value;

        [Column(nameof(Value))]
        [JsonIgnore]
        public string Json
        {
            get => Value.Json.ToString(Formatting.None);
            private set
            {
                if (VariableValue.TryParse(value, out var json))
                {
                    Value.Json = json;
                }
            }
        }
    }
}
